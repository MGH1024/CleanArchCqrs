using Application.Contracts.Messaging;
using Application.Responses;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand:ICommand<BaseCommandResponse>
{
    public DTOs.Category.DeleteCategory DeleteCategory { get; set; }
}