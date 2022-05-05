using System;
using FunmulaUno.Post.Controllers;
using FunmulaUno.Post.Handlers;
using FunmulaUno.Post.Migrations;
using FunmulaUno.Post.Models;
using FunmulaUno.Post.Permissions;
using FunmulaUno.Post.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;

namespace FunmulaUno.Post
{

    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<F1PostPart>()
                .AddHandler<F1PostHandler>();
            services.AddScoped<IDataMigration, F1PostPartMigrations>();
            services.AddScoped<IF1PostServices, F1PostServices>();
            services.AddScoped<IPermissionProvider, F1PostPermission>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "FunmulaUno.Post.Home",
                areaName: "FunmulaUno.Post",
                pattern: string.Empty,
                defaults: new { controller = typeof(F1PostController), action = nameof(F1PostController.List) }
            );
        }
    }
}