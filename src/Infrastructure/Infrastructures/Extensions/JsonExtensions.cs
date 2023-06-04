using Application.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Infrastructures.Extensions;

public static class JsonExtensions
{
    public static string ToJsonString(ApiResponse apiResponse)
    {
        return JsonConvert.SerializeObject(apiResponse, JsonSettings());
    }

    private static JsonSerializerSettings JsonSettings()
    {
        return new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };
    }
}