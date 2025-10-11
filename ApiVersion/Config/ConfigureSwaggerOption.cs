using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;


namespace APIVersion.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Title = $"Sample API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "API with versioning support ",
                };

                if (description.IsDeprecated)
                {
                    info.Description += " This API version has been deprecated.";
                }
                options.SwaggerDoc(description.GroupName, info);
            }

            options.DocInclusionPredicate((docName, apiDec) => apiDec.GroupName == docName);
        }
    }
}