using System.Collections.Generic;
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
