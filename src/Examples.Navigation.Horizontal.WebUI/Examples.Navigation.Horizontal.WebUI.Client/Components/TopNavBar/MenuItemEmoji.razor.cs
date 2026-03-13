// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

/// <summary>
/// Represents a Blazor component for displaying an emoji icon within a menu item in the top navigation bar.
/// </summary>
public partial class MenuItemEmoji
{
    /// <summary>
    /// Gets or sets the emoji character or font icon to be displayed in the menu item.
    /// </summary>
    [Parameter]
    public string? FontEmoji { get; set; }
}