using System.Text.Json;
using Application.Models.Responses;

namespace Application.Extensions;

public static class JsonExtensions
{
    public static string ToJsonString(ApiResponse apiResponse)
    {
        return JsonSerializer.Serialize(apiResponse);
    }

    // private static JsonSerializerSettings JsonSettings()
    // {
    //     return new JsonSerializerSettings
    //     {
    //         ContractResolver = new CamelCasePropertyNamesContractResolver(),
    //         Converters = new List<JsonConverter> { new StringEnumConverter() }
    //     };
    // }
}