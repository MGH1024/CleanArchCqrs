using MediatR;

namespace Application.Contracts.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}