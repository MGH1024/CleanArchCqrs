using MediatR;
using Application.Responses;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryListRequest : IRequest<BaseQueryResponse<List<CategoryDetail>>>
{
}