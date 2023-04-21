using MediatR;
using Application.DTOs.Category;

namespace Application.Features.Category.Requests.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public CreateCategory CreateCategory { get; set; }
}