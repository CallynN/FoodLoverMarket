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
    partial class CN001CreateBranchView : Shared.Theme.Controls.Form
    {
        CN001CreateBranch _controller;
        public CN001CreateBranchView(CN001CreateBranch controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}