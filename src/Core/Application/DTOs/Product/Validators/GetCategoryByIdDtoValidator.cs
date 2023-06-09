﻿using FluentValidation;

namespace Application.DTOs.Product.Validators;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdDto>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}