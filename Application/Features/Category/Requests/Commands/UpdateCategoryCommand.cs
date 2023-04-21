using MediatR;
using Application.Responses;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Commands;

public class UpdateCategoryCommand : IRequest<BaseCommandResponse>
{
    public UpdateCategory UpdateCategory { get; set; }
}