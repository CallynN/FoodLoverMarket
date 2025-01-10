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
    partial class CN008ViewProductsView : Shared.Theme.Controls.Form
    {
        CN008ViewProducts _controller;
        public CN008ViewProductsView(CN008ViewProducts controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}