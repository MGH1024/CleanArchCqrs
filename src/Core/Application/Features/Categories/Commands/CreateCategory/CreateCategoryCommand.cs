using Application.Contracts.Messaging;
using Application.Responses;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand:ICommand<BaseCommandResponse>
{
    public DTOs.Category.CreateCategory CreateCategory { get; set; }
}