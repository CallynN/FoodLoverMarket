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
    partial class CN002EditBranchView : Shared.Theme.Controls.Form
    {
        CN002EditBranch _controller;
        public CN002EditBranchView(CN002EditBranch controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    } 
}