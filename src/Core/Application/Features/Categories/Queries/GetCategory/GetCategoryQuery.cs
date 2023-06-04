using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Models.Responses;

namespace Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQuery:IQuery<ApiResponse>
{
    public int Id { get; set; }
}