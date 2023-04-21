using Application.DTOs.Shop.Category;
using MediatR;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryRequest:IRequest<CategoryDetail>
{
    public int Id { get; set; }
}