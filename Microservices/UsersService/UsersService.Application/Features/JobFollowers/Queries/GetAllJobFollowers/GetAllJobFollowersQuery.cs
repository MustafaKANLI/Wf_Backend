﻿namespace UsersService.Application.Features.JobFollowers.Queries.GetAllJobFollowers;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;
using UsersService.Domain.Entities;

public class GetAllJobFollowersQuery : IRequest<PagedResponse<IEnumerable<JobFollowerViewModel>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetAllJobFollowersQueryHandler : IRequestHandler<GetAllJobFollowersQuery, PagedResponse<IEnumerable<JobFollowerViewModel>>>
{
    private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobFollowersQueryHandler(IJobFollowerRepositoryAsync JobFollowerRepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobFollowerRepository = JobFollowerRepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<PagedResponse<IEnumerable<JobFollowerViewModel>>> Handle(GetAllJobFollowersQuery request, CancellationToken cancellationToken)
    {
        var dataCount = await _JobFollowerRepository.GetDataCount();
        var JobFollowers = await _JobFollowerRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

        var JobFollowerViewModels = new List<JobFollowerViewModel>();

        foreach (var p in JobFollowers)
        {
            var JobFollower = p.Adapt<JobFollowerViewModel>();
            JobFollowerViewModels.Add(JobFollower);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobFollower.JobName = Job.Name;

            var User = await _UserRepository.GetByIdAsync(p.UserId);
            if (User == null)
            {
                throw new ApiException("User cannot found!");
            }
            JobFollower.UserName = User.FullName;
        }

        return new PagedResponse<IEnumerable<JobFollowerViewModel>>(JobFollowerViewModels, request.PageNumber, request.PageSize, dataCount);
    }
}
