using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Commands;

public class DeleteCategoryCommand : IRequest
{
    public DeleteCategory DeleteCategory { get; set; }
}