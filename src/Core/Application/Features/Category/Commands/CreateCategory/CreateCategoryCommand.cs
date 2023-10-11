﻿using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand:ICommand<ApiResponse>
{
    public CreateCategoryDto CreateCategory { get; set; }
}