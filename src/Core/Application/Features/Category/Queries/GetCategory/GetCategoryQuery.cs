using Application.Models.Responses;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQuery:IRequest<ApiResponse>
{
    public int Id { get; set; }
}