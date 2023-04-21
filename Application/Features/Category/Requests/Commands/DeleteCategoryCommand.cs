using MediatR;
using Application.Responses;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Commands;

public class DeleteCategoryCommand : IRequest<BaseCommandResponse>
{
    public DeleteCategory DeleteCategory { get; set; }
}