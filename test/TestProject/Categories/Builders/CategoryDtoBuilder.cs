using Application.DTOs.Category.Base;

namespace TestProject.Categories.Builders;

public class CategoryDtoBuilder
{
    private int _id;
    private int _code;
    private string _title;
    private string _description;

    public CategoryDtoBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public CategoryDtoBuilder WithCode(int code)
    {
        _code = code;
        return this;
    }

    public CategoryDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public CategoryDtoBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public CategoryDto Build()
    {
        return new CategoryDto
        {
            Id = _id,
            Code = _code,
            Title = _title,
            Description = _description,
        };
    }
}