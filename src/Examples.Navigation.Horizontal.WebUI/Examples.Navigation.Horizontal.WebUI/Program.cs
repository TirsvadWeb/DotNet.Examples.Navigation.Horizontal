// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Infrastructure;
using Examples.Navigation.Horizontal.WebUI.Components;

namespace Examples.Navigation.Horizontal.WebUI;

/// <summary>
/// Entry point for the Blazor WebAssembly application.
/// Configures services, middleware, and application pipeline for the Examples.Navigation.Horizontal.WebUI project.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method that initializes and runs the web application.
    /// Sets up configuration, dependency injection, and middleware for both server-side and WebAssembly Blazor components.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Create the web application builder with default configuration and services.
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Register infrastructure services required by the application.
        _ = builder.Services.AddInfrastructureServices();

        // Add configuration for the navigation bar from a JSON file.
        _ = builder.Configuration.AddJsonFile("wwwroot/mainMenu.json", optional: false, reloadOnChange: true);

        // Register Blazor component services for both server and WebAssembly interactivity.
        _ = builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        // Build the web application.
        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline based on the environment.
        if (app.Environment.IsDevelopment())
        {
            // Enable debugging for WebAssembly in development.
            app.UseWebAssemblyDebugging();
        }
        else
        {
            // Use a custom error handler and enable HSTS in production.
            _ = app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _ = app.UseHsts();
        }

        // Configure status code pages, HTTPS redirection, and antiforgery protection.
        _ = app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        _ = app.UseHttpsRedirection();
        _ = app.UseAntiforgery();

        // Map static assets and configure Blazor component rendering modes.
        _ = app.MapStaticAssets();
        _ = app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        // Run the application.
        app.Run();
    }
}
