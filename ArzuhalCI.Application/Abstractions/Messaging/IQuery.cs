using ArzuhalCI.SharedKernel;
using MediatR;

namespace ArzuhalCI.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
