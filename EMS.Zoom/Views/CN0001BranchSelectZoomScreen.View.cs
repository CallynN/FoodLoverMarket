using ENV;
using ENV.Data;
using Firefly.Box;
using Firefly.Box.UI.Advanced;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.Zoom.Views
{
    partial class CN0001BranchSelectZoomScreenView : Shared.Theme.Controls.Form
    {
        CN0001BranchSelectZoomScreen _controller;
        public CN0001BranchSelectZoomScreenView(CN0001BranchSelectZoomScreen controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void button1_Click(object sender, ButtonClickEventArgs e)
        {
            e.Raise(Command.Select);
        }

        private void button2_Click(object sender, ButtonClickEventArgs e)
        {
            e.Raise(ENV.Commands.CustomCommand_20);
        }
    }
}