using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QuizApp.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
            }
        }

        private OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "QuizApp Web API",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                apiInfo.Description =
                    "This api has been deprecated. Please use one of the new APIs available from the explorer";
            }

            return apiInfo;
        }
    }
}
