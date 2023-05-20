using Common.Wrappers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobFiles.Commands;

public class CreateJobFileCommand : IRequest<Response<string>>
{
    public int JobId { get; set; }
    public int UserId { get; set; }
    public IFormFile File { get; set; }


}

public class CreateJobFileCommandHandler : IRequestHandler<CreateJobFileCommand, Response<string>>
{
    private readonly IJobFileRepositoryAsync _JobFileRepository;
    public CreateJobFileCommandHandler(IJobFileRepositoryAsync JobFileRepository)
    {
        _JobFileRepository = JobFileRepository;
    }

    public async Task<Response<string>> Handle(CreateJobFileCommand request, CancellationToken cancellationToken)
    {
        byte[] fileContent = null;
        if (request.File != null && request.File.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await request.File.CopyToAsync(memoryStream);
                fileContent = memoryStream.ToArray();
            }
        }

        var JobFile = request.Adapt<JobFile>();

        // TODO: İlgili id'lere sahip kullanıcı ve işin olup olmadığının kontrolü sağlanacak

        JobFile.FileContent = fileContent;
        JobFile.JobId = request.JobId;
        JobFile.UserId = request.UserId;
        JobFile.Date = DateTime.Now;
        JobFile.ContentType = request.File.ContentType;
        JobFile.Name = request.File.FileName;
        JobFile.FileSize = (int)request.File.Length;


        await _JobFileRepository.AddAsync(JobFile);

        return new Response<string>(JobFile.Id.ToString(), "JobFile created");
    }
}