using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommand:ICommand<ApiResponse>
{
    public DeleteCategoryDto DeleteCategoryDto { get; set; }
}