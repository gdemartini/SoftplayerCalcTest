﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SoftplayerCalcTest.Services;

namespace SoftplayerCalcTest
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc()
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
          options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddSwaggerDocumentation();

      // Adding as singleton, since it's completely stateless
      services.AddSingleton<IInterestCalculatorService, InterestCalculatorService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwaggerDocumentation();
      app.UseMvc();
    }
  }
}
