﻿namespace EMS.Shared.Theme.Printing
{
    partial class Grid
    {
        void InitializeComponent()
        {
            ColorScheme = new EMS.Shared.Theme.Colors.DefaultPrintFormColor();
            DrawPartialRow = false;
            Style = Firefly.Box.UI.ControlStyle.Flat;
            Scrollbar = false;
            LastColumnHeaderSeparator = false;
            WidthByColumns = true;
            DoubleColumnSeparatorInFlatStyle = true;
            RightToLeftLayout = false;
        }
    }
}
