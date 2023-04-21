using Application.DTOs.Shop.Category;
using MediatR;

namespace Application.Features.Category.Requests.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public CreateCategory CreateCategory { get; set; }
}