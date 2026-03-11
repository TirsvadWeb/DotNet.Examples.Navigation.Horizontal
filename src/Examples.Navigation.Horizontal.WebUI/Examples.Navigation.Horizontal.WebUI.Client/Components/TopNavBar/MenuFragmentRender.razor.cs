// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

public partial class MenuFragmentRender
{
    [Parameter]
    public MenuFragment MenuFragment { get; set; } = default!;

    [Parameter]
    public int MenuLevel { get; set; } = 0;

    [Parameter]
    public bool IsNavCollapsed { get; set; }

    private string Link => MenuFragment.Url ?? "#";
    private bool HasChildren => MenuFragment.Children != null && MenuFragment.Children.Count > 0;
    private string Title => MenuFragment.Title ?? "Untitled";
    private string FontClassEmoji => MenuFragment.FontClassEmoji ?? "";
    private bool HasParent => MenuFragment.ParentId != null;
    private bool HasFontClassEmoji => MenuFragment.FontClassEmoji is not null;

    private string GetCssClassForA()
    {
        return HasParent
            ? HasChildren ? "dropdown-item dropdown-toggle" : "nav-link"
            : HasChildren ? "nav-link dropdown-toggle" : "nav-link";
    }

    private string GetCssClassForLi()
    {
        // If in burger menu (collapsed), do not use dropdown-submenu
        return IsNavCollapsed
            ? HasChildren
                ? MenuLevel == 0 ? "nav-item dropdown" : "nav-item"
                : MenuLevel == 0 ? "nav-item" : ""
            : HasChildren
            ? MenuLevel == 0 ? "nav-item dropdown" : "dropdown-submenu"
            : MenuLevel == 0 ? "nav-item" : "";
    }
}