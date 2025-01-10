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

namespace EMS.MasterData.Views
{
    partial class CN004ViewBranchView : Shared.Theme.Controls.Form
    {
        CN004ViewBranch _controller;
        public CN004ViewBranchView(CN004ViewBranch controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}