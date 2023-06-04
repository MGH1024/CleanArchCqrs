using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : ICommand<ApiResponse>
{
    public DTOs.Category.UpdateCategory  UpdateCategory { get; set; }
}