using ArzuhalCI.Application.Customers.Add;
using ArzuhalCI.Application.Customers.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArzuhalCI.Web.Api.Controllers.Customers;

[Route("api/customers")]
[Authorize]
public class CustomersController : BaseController
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet(Name = "GetCustomers")]
    public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
    {
        var query = new GetCustomers();

        var result = await _mediator.Send(query, cancellationToken);

        return result.IsFailure
            ? HandleApplicationError(result.Error)
            : Ok(result.Value);
    }

    [HttpGet("{customerId}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(Guid customerId, CancellationToken cancellationToken)
    {
        var query = new GetCustomer(customerId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.IsFailure
            ? HandleApplicationError(result.Error)
            : Ok(result.Value);
    }

    [HttpPost(Name = "AddCustomer")]
    public async Task<IActionResult> AddCustomer(AddCustomerRequest request, CancellationToken cancellationToken)
    {
        var command = new AddCustomer(request.Email, request.Name, request.IdentityId);

        var result = await _mediator.Send(command, cancellationToken);

        return result.IsFailure
            ? HandleApplicationError(result.Error)
            : CreatedAtRoute("GetCustomerById", new { customerId = result.Value }, result.Value);
    }
}