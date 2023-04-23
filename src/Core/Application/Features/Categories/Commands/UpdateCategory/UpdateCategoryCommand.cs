using Application.Contracts.Messaging;
using Application.Responses;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : ICommand<BaseCommandResponse>
{
    public DTOs.Category.UpdateCategory  UpdateCategory { get; set; }
}