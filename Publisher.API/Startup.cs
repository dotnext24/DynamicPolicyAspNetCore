using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MassTransit;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Publisher.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAspNetCoreMassTransit(config =>
            {
                config.SetupConnection(connection =>
                {
                    connection.RabbitMQConnectionString = "localhost";
                    connection.Username = "guest";
                    connection.Password = "guest";
                    connection.Timeout = 60;
                });

                config.AddRequestMessage<Request>("Test.Receiver");
            });

            // This is service provider for create instance of DI object
            ServiceProvider provider = services.BuildServiceProvider();

            IMassTransitRequest<Request> massTransitRequest = provider.GetService<IMassTransitRequest<Request>>();

            massTransitRequest.Send(new Request()
            {
                TestMessage = "This is test message"

            }).GetAwaiter().GetResult();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }
    }
}
