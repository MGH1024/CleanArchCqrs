using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Responses;

namespace Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery :IQuery<BaseQueryResponse<List<CategoryDetail>>>
{
    
}