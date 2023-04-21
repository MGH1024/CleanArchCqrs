using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Queries;

public class GetCategoryRequest:IRequest<CategoryDetail>
{
    public int Id { get; set; }
}