using TechFayre.Gql.Data;
using TechFayre.Gql.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server;
using GraphQL.Server.Ui.Voyager;
using TechFayre.Gql.Schemas;
using GraphQL;
using GraphQL.Http;
using TechFayre.Gql.Models;
using System.Collections.Generic;
using TechFayre.Gql.Schemas.Type;
using TechFayre.Gql.Schemas.InputType;
using System;

namespace TechFayre.Gql
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<BlogRepository>();
            services.AddSingleton<TechFayreSchema>();
            services.AddSingleton<TechFayreQuery>();
            services.AddSingleton<TechFayreMutation>();
            services.AddSingleton<TechFayreSubscriptions>();
            services.AddSingleton<BlogType>();
            services.AddSingleton<BlogInputType>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddDataLoader();

            services.AddMvc();

            //services.AddDbContext<CarvedRockDbContext>(options =>
            //    options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]));
            //services.AddSingleton<ProductRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseWebSockets();

            app.UseGraphQL<TechFayreSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/ui/voyager"
            });

            app.UseMvc();
        }
    }
}