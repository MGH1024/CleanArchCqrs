using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryListRequest : IRequest<List<CategoryDetail>>
{
        
}