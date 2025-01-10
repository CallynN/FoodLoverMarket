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
    partial class CN013CreateBranchProductView : Shared.Theme.Controls.Form
    {
        CN013CreateBranchProduct _controller;
        public CN013CreateBranchProductView(CN013CreateBranchProduct controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}