using MediatR;

namespace Application.Contracts.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}