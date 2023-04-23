using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Responses;

namespace Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQuery:IQuery<BaseQueryResponse<CategoryDetail>>
{
    public int Id { get; set; }
}