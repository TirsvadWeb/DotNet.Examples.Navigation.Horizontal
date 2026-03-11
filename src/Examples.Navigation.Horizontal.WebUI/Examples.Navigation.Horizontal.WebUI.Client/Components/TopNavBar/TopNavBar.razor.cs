// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Services;
using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

public partial class TopNavBar : ComponentBase
{
    [Inject]
    private IMenuService MenuService { get; set; } = default!;

    private IEnumerable<MenuFragment> _menuItems = [];

    private bool _isNavCollapsed = true;

    private void ToggleNavMenu()
    {
        _isNavCollapsed = !_isNavCollapsed;
    }

    /// <summary>
    /// Loads the menu items asynchronously when the component is initialized.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        _menuItems = await MenuService.GetMenuTreeAsync();
    }
}