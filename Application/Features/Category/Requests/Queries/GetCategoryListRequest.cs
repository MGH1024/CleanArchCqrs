using Application.DTOs.Shop.Category;
using MediatR;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryListRequest : IRequest<List<CategoryDetail>>
{
        
}