using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Models.Responses;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : ICommand<ApiResponse>
{
    public UpdateCategoryDto  UpdateCategoryDto { get; set; }
}