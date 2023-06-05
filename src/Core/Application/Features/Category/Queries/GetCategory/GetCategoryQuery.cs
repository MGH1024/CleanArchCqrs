using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQuery:IQuery<ApiResponse>
{
    public int Id { get; set; }
}