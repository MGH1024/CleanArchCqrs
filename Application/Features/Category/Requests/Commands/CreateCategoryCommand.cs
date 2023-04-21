using MediatR;
using Application.DTOs.Category;
using Application.Responses;

namespace Application.Features.Category.Requests.Commands;

public class CreateCategoryCommand : IRequest<BaseCommandResponse>
{
    public CreateCategory CreateCategory { get; set; }
}