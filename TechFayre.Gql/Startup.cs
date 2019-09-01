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
            services.AddMvc();
            services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]));
            services.AddSingleton<ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, CarvedRockDbContext dbContext)
        {
            app.UseMvc();
            app.UseWebSockets();
            dbContext.Seed();

            // this is required for websockets support
            app.UseWebSockets();

            // use HTTP middleware for ChatSchema at path /graphql
            app.UseGraphQL<TechFayreSchema>("/graphql");

            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
        }
    }
}