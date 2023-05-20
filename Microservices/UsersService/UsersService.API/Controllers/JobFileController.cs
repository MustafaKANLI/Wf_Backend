namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobFiles.Commands;
using UsersService.Application.Features.JobFiles.Queries.GetAllJobFiles;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobFiles.Queries.GetById;
using UsersService.Application.Features.JobFiles.Queries.DownloadFile;
using UsersService.Domain.Entities;
using UsersService.Application.Interfaces.Repositories;

public class JobFileController : BaseApiController
{

    private IJobFileRepositoryAsync _jobFileRepositoryAsync;

    public JobFileController(IJobFileRepositoryAsync jobFileRepositoryAsync)
    {
        _jobFileRepositoryAsync = jobFileRepositoryAsync;

    }

    // POST api/<controller>
    [HttpPost("/api/JobFiles/Add")]
    public async Task<IActionResult> Create(int JobId, int UserId, IFormFile file)
    {
        return Ok(await Mediator.Send(new CreateJobFileCommand() { JobId = JobId, UserId = UserId, File = file }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobFiles/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobFilesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobFiles/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobFiles/DownloadFile")]
    public async Task<IActionResult> DownloadFile(int jobFileId)
    {
        var result = await _jobFileRepositoryAsync.GetByIdAsync(jobFileId);

        byte[] file = Convert.FromBase64String(Convert.ToBase64String(result.FileContent)); //Base64 kayıtlı bilgiyi getireceğiz
        return File(file, result.FileContent, result.Name); //content type güncelleyeceğiz //"text/css"


    }

    private IActionResult File(byte[] file, byte[] fileContent, string name)
    {
        // Specify the content type based on the file extension or your specific requirements
        string contentType = "application/octet-stream"; // Example: application/pdf, image/jpeg, etc.

        // Return the file as a downloadable attachment
        return File(file, contentType, name);
    }

}
