using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand:ICommand<ApiResponse>
{
    public DTOs.Category.DeleteCategory DeleteCategory { get; set; }
}