using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace SoftplayerCalcTest
{
  public static class SwaggerExtensions
  {
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
      var thisAssembly = typeof(Program).Assembly;
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Version = "v1", Title = $"Softplayer Calc Test v{ thisAssembly.GetName().Version }" });

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softplayer Calc Test API v1");
        c.RoutePrefix = string.Empty;

        c.DocumentTitle = "Softplayer Calc Test API v1";
        c.DocExpansion(DocExpansion.List);
      });

      return app;
    }
  }
}
