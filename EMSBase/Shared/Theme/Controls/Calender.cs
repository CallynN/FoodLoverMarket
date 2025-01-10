using System.Drawing;
using Firefly.Box.UI;
using Firefly.Box;
using ENV;
using ENV.Data;
using System.Windows.Forms;
using System;
using System.Globalization;

namespace EMS.Shared.Theme.Controls
{

    /// <summary>Calender</summary>
    public partial class Calender : ENV.UI.TextBox
    {

        DateTimePicker btn;
        public readonly DateColumn Date = new DateColumn();
        /// <summary>Calender</summary>
        public Calender()
        {
            InitializeComponent();
            this.ShowExpandButton = true;
            this.Data = Date;
            #region Add datePicker
            btn = new DateTimePicker();
            btn.Size = new Size(17, this.ClientSize.Height + 2);
            btn.Location = new Point(this.ClientSize.Width - btn.Width, -1);
            btn.Cursor = Cursors.Default;
            this.Controls.Add(btn);

            btn.ValueChanged += CalenderDate;
            btn.Enter += onEnter;
            btn.CloseUp += dateTimeLeave;
            //this.
            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));

            #endregion
            #region  On Resize my Button
            var binding = new Binding("Location", this, "ClientSize");
            binding.Format += (s, e) => e.Value = e.Value is Size ? new Point(((Size)e.Value).Width - btn.Width, -1) : new Point(0, 0);
            btn.DataBindings.Add(binding);

            #endregion

            Date.DefaultValue = btn.Value;
        }

        private void CalenderDate(object sender, EventArgs e)
        {
            Date.Value = btn.Value;
            this.Text = Date.Value.ToString();
        }

        private void onEnter(object sender, EventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            // It throws Argument null exception  
            DateTime temp;
            if (DateTime.TryParseExact(this.Text, "dd/MM/yyyy", provider, DateTimeStyles.None, out temp) == true)
            {
                DateTime dateTime = DateTime.ParseExact(this.Text, "dd/MM/yyyy", provider);
                btn.Value = dateTime;

            }
        }

        private void dateTimeLeave(object sender, EventArgs e)
        {
            this.Focus();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void Calender_ValueChanged(object sender, System.EventArgs e)
        {
            SendKeys.SendWait(".");

        }

    }



}
