namespace UsersService.Application.Features.JobFilesByJobId.Queries.GetAllJobFilesByJobId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobFilesByJobIdQuery : IRequest<ListedResponse<IEnumerable<JobFileViewModel>>>
{
    public int JobId { get; set; }
}

public class GetAllJobFilesByJobIdQueryHandler : IRequestHandler<GetAllJobFilesByJobIdQuery, ListedResponse<IEnumerable<JobFileViewModel>>>
{
    private readonly IJobFileRepositoryAsync _JobFileRepository;

    public GetAllJobFilesByJobIdQueryHandler(IJobFileRepositoryAsync JobFileRepository)
    {
        _JobFileRepository = JobFileRepository;
    }

    public async Task<ListedResponse<IEnumerable<JobFileViewModel>>> Handle(GetAllJobFilesByJobIdQuery request, CancellationToken cancellationToken)
    {
        var JobFiles = await _JobFileRepository.GetJobFilesByJobIdAsync(request.JobId);
        var dataCount = JobFiles.Count;

        var JobFileViewModels = new List<JobFileViewModel>();

        foreach (var p in JobFiles)
        {
            var JobFile = p.Adapt<JobFileViewModel>();
            JobFileViewModels.Add(JobFile);
        }

        return new ListedResponse<IEnumerable<JobFileViewModel>>(JobFileViewModels, dataCount);
    }

}
