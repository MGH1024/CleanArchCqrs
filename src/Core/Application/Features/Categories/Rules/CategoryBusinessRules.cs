using Application.Features.Auth.Constants;
using Application.Features.Categories.Constant;
using MGH.Core.Application.Rules;
using MGH.Core.CrossCutting.Exceptions.Types;

namespace Application.Features.Category.Rules;

public class CategoryBusinessRules :BaseBusinessRules
{
    public Task CategoryTitleShouldNotBeDuplicate(Domain.Entities.Shop.Category category)
    {
        if (category is not null)
            throw new BusinessException(CategoryMessages.DuplicateTitle);
        return Task.CompletedTask;
    }
}