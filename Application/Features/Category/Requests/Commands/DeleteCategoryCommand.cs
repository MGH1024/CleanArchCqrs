using Application.DTOs.Shop.Category;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public class DeleteCategoryCommand : IRequest
{
    public DeleteCategory DeleteCategory { get; set; }
}