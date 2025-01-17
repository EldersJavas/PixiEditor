﻿using PixiEditor.Models.DataHolders;

namespace PixiEditor.Models.Commands;

public class ShortcutChangedEventArgs : EventArgs
{
    public KeyCombination OldShortcut { get; }
    
    public KeyCombination NewShortcut { get; }
    
    public ShortcutChangedEventArgs(KeyCombination oldShortcut, KeyCombination newShortcut)
    {
        OldShortcut = oldShortcut;
        NewShortcut = newShortcut;
    }
}