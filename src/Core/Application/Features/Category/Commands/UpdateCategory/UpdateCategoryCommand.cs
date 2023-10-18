using Application.Models.Responses;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ApiResponse>
{
    public UpdateCategoryDto  UpdateCategoryDto { get; set; }
}