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
    partial class CN005CreateProductView : Shared.Theme.Controls.Form
    {
        CN005CreateProduct _controller;
        public CN005CreateProductView(CN005CreateProduct controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}