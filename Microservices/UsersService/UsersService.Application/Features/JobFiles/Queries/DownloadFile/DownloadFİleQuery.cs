namespace UsersService.Application.Features.JobFiles.Queries.DownloadFile;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using UsersService.Domain.Entities;

public class DownloadFileQuery : IRequest<Response<DownloadableJobFileViewModel>>
{
    public int Id { get; set; }

}

public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, Response<DownloadableJobFileViewModel>>
{
    private readonly IJobFileRepositoryAsync _JobFileRepository;
    public DownloadFileQueryHandler(IJobFileRepositoryAsync JobFileRepository)
    {
        _JobFileRepository = JobFileRepository;
    }

    public async Task<Response<DownloadableJobFileViewModel>> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
