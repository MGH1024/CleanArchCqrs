using Application.Contracts.Messaging;
using Application.Models.Responses;
using Application.DTOs.Categories;

namespace Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryCommand:ICommand<ApiResponse>
{
    public DTOs.Categories.CreateCategory CreateCategory { get; set; }
}