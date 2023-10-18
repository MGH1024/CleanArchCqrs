using Application.Models.Responses;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<ApiResponse>
{
    public CreateCategoryDto CreateCategory { get; set; }
}