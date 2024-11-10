using ArzuhalCI.Application.Entries.Add;
using ArzuhalCI.Application.Entries.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArzuhalCI.Web.Api.Controllers.Entries;

[Route("api/entries")]
[Authorize]
public class EntriesController : BaseController
{
    private readonly IMediator _mediator;

    public EntriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{entryId}", Name = "GetEntry")]
    public async Task<IActionResult> GetEntry(Guid entryId, CancellationToken cancellationToken)
    {
        var query = new GetEntry(entryId);
        var result = await _mediator.Send(query, cancellationToken);
        return result.IsFailure
            ? HandleApplicationError(result.Error)
            : Ok(result.Value);
    }



    [HttpPost]
    public async Task<IActionResult> Add(AddEntryRequest request, CancellationToken cancellationToken)
    {
        var command = new AddEntry(request.Prompt);
        var result = await _mediator.Send(command, cancellationToken);

        return result.IsFailure
            ? HandleApplicationError(result.Error)
            : CreatedAtRoute("GetEntry", new { entryId = result.Value }, result.Value);
    }
}