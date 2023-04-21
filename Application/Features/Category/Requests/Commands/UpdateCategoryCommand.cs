using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public UpdateCategory UpdateCategory { get; set; }
}