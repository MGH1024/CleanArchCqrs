using Application.DTOs.Shop.Category;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public UpdateCategory UpdateCategory { get; set; }
}