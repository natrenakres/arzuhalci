using ArzuhalCI.SharedKernel;
using MediatR;

namespace ArzuhalCI.Application.Abstractions.Messaging;

public interface ITransactionalCommand : ICommand
{}

public interface ITransactionalCommand<TResponse> : IRequest<Result<TResponse>>, ITransactionalCommand
{}
