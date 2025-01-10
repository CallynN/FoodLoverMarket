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
    partial class CN006EditProductView : Shared.Theme.Controls.Form
    {
        CN006EditProduct _controller;
        public CN006EditProductView(CN006EditProduct controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}