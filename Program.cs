﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebCore.API.Models;
using System;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebCore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Program>()
                .Build();



            host.Run();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<INoteRepository,NoteRepository>();
            services.AddSingleton<IBlogRepository,BlogRepository>();
            services.AddSingleton<IModalidadRepository,ModalidadRepository>();;

            Console.WriteLine("Program.Services");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }

    }
}