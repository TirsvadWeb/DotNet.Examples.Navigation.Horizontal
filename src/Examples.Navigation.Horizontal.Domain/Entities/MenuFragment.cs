// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Interfaces;

namespace Examples.Navigation.Horizontal.Domain.Entities;

/// <summary>
/// Represents a fragment of a menu structure, which can be used to build hierarchical navigation menus.
/// </summary>
/// <remarks>
/// Each <see cref="MenuFragment"/> instance can have child fragments, allowing for nested menu structures.
/// </remarks>
public class MenuFragment : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the menu fragment.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the display title of the menu fragment.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the URL associated with the menu fragment. Can be null or empty if not applicable.
    /// </summary>
    public string? Url { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the CSS class or emoji representing the menu fragment icon.
    /// </summary>
    public string? FontClassEmoji { get; set; }

    /// <summary>
    /// Gets or sets the order in which the menu fragment appears relative to its siblings.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the menu fragment is visible.
    /// </summary>
    public bool IsVisible { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the menu fragment is enabled for interaction.
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Gets or sets the identifier of the parent menu fragment, if any.
    /// </summary>
    public Guid? ParentId { get; set; }

    #region Navigation Properties
    /// <summary>
    /// Gets or sets the collection of child menu fragments.
    /// </summary>
    public virtual ICollection<MenuFragment>? Children { get; set; }
    #endregion
}
