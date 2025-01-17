﻿using System.Windows.Input;

namespace PixiEditor.Models.Commands.Attributes;

public partial class Command
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ToolAttribute : CommandAttribute
    {
        public Key Transient { get; set; }

        public ToolAttribute() : base(null, null, null)
        {
        }
    }
}
