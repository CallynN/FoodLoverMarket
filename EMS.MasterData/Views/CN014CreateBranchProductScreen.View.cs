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
    partial class CN014CreateBranchProductScreenView : Shared.Theme.Controls.Form
    {
        CN014CreateBranchProductScreen _controller;
        public CN014CreateBranchProductScreenView(CN014CreateBranchProductScreen controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}