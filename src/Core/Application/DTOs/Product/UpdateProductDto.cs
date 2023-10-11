﻿namespace Application.DTOs.Product;

public class UpdateProductDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
}