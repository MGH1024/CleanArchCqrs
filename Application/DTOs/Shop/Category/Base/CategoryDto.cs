﻿using Application.DTOs.Base;

namespace Application.DTOs.Shop.Category.Base
{
    public class CategoryDto:BaseDto
    {
        public int Code { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
    }
}
