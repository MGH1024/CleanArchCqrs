using MediatR;
using Application.Responses;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryRequest:IRequest<BaseQueryResponse<CategoryDetail>>
{
    public int Id { get; set; }
}