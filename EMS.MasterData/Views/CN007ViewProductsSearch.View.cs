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
    partial class CN007ViewProductsSearchView : Shared.Theme.Controls.Form
    {
        CN007ViewProductsSearch _controller;
        public CN007ViewProductsSearchView(CN007ViewProductsSearch controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}