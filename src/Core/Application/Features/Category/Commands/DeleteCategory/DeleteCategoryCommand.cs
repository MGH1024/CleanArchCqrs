using MediatR;
using Application.Models.Responses;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand:IRequest<ApiResponse>
{
    public DeleteCategoryDto DeleteCategoryDto { get; set; }
}