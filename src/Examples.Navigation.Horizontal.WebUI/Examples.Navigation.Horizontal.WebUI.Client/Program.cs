// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Infrastructure;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Examples.Navigation.Horizontal.WebUI.Client;

/// <summary>
/// Entry point for the Blazor WebAssembly client application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Configures and runs the Blazor WebAssembly host.
    /// Initializes the service container, loads navigation bar configuration from a JSON file,
    /// and starts the application.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the application.</param>
    private static async Task Main(string[] args)
    {
        // Create the default WebAssembly host builder with the provided arguments.
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Register infrastructure services required by the application.
        _ = builder.Services.AddInfrastructureServices();

        // Load the navigation bar configuration from the navBar.json file and add it to the configuration system.
        await NavBarConfigurationLoader.LoadAsync(builder);

        // Build and run the Blazor WebAssembly host.
        await builder.Build().RunAsync();
    }
}
