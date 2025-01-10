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
    partial class CN003ViewBranchSearchView : Shared.Theme.Controls.Form
    {
        CN003ViewBranchSearch _controller;
        public CN003ViewBranchSearchView(CN003ViewBranchSearch controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void textBox1_Change()
        {

        }
    }
}