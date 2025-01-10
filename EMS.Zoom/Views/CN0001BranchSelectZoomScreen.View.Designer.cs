
namespace EMS.Zoom.Views
{
    partial class CN0001BranchSelectZoomScreenView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid1 = new EMS.Shared.Theme.Controls.Grid();
            this.gcId = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtId = new EMS.Shared.Theme.Controls.TextBox();
            this.gcName = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtName = new EMS.Shared.Theme.Controls.TextBox();
            this.button1 = new EMS.Shared.Theme.Controls.Button();
            this.button2 = new EMS.Shared.Theme.Controls.Button();
            this.grid1.SuspendLayout();
            this.gcId.SuspendLayout();
            this.gcName.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Controls.Add(this.gcId);
            this.grid1.Controls.Add(this.gcName);
            this.grid1.Location = new System.Drawing.Point(3, 3);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(431, 223);
            this.grid1.Text = "grid1";
            // 
            // gcId
            // 
            this.gcId.Controls.Add(this.txtId);
            this.gcId.Name = "gcId";
            this.gcId.Text = "Branch";
            // 
            // txtId
            // 
            this.txtId.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtId.Location = new System.Drawing.Point(2, 1);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(114, 21);
            this.txtId.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtId.Data = this._controller.Branch_.Id;
            // 
            // gcName
            // 
            this.gcName.Controls.Add(this.txtName);
            this.gcName.Name = "gcName";
            this.gcName.Text = "Name";
            this.gcName.Width = 285;
            // 
            // txtName
            // 
            this.txtName.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtName.Location = new System.Drawing.Point(2, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 21);
            this.txtName.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtName.Data = this._controller.Branch_.Name;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Text = "Select";
            this.button1.Click += new Firefly.Box.UI.Advanced.ButtonClickEventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.Text = "Cancle";
            this.button2.Click += new Firefly.Box.UI.Advanced.ButtonClickEventHandler(this.button2_Click);
            // 
            // CN0001BranchSelectZoomScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 285);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN0001BranchSelectZoomScreenView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN0001BranchSelectZoomScreen";
            this.VerticalExpressionFactor = 1D;
            this.grid1.ResumeLayout(false);
            this.gcId.ResumeLayout(false);
            this.gcName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.Grid grid1;
        private Shared.Theme.Controls.GridColumn gcId;
        private Shared.Theme.Controls.TextBox txtId;
        private Shared.Theme.Controls.GridColumn gcName;
        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.Button button1;
        private Shared.Theme.Controls.Button button2;
    }
}