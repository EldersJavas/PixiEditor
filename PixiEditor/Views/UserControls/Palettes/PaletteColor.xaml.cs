﻿using System.Windows;
using System.Windows.Controls;
using SkiaSharp;

namespace PixiEditor.Views.UserControls.Palettes;

public partial class PaletteColor : UserControl
{
    public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
        "Color", typeof(SKColor), typeof(PaletteColor), new PropertyMetadata(default(SKColor)));

    public SKColor Color
    {
        get { return (SKColor)GetValue(ColorProperty); }
        set { SetValue(ColorProperty, value); }
    }


    public int? AssociatedKey
    {
        get { return (int?)GetValue(AssociatedKeyProperty); }
        set { SetValue(AssociatedKeyProperty, value); }
    }

    // Using a DependencyProperty as the backing store for AssociatedKey.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty AssociatedKeyProperty =
        DependencyProperty.Register("AssociatedKey", typeof(int?), typeof(PaletteColor), new PropertyMetadata(null));

    public CornerRadius CornerRadius
    {
        get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PaletteColor), new PropertyMetadata(new CornerRadius(5f)));



    public PaletteColor()
    {
        InitializeComponent();
    }
}