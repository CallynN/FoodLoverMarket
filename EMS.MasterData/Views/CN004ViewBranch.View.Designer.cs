
namespace EMS.MasterData.Views
{
    partial class CN004ViewBranchView
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
            this.gcTelephoneNumber = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtTelephoneNumber = new EMS.Shared.Theme.Controls.TextBox();
            this.gcOpenDate = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtOpenDate = new EMS.Shared.Theme.Controls.TextBox();
            this.gcStatus = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtStatus = new EMS.Shared.Theme.Controls.TextBox();
            this.grid1.SuspendLayout();
            this.gcId.SuspendLayout();
            this.gcName.SuspendLayout();
            this.gcTelephoneNumber.SuspendLayout();
            this.gcOpenDate.SuspendLayout();
            this.gcStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Controls.Add(this.gcId);
            this.grid1.Controls.Add(this.gcName);
            this.grid1.Controls.Add(this.gcTelephoneNumber);
            this.grid1.Controls.Add(this.gcOpenDate);
            this.grid1.Controls.Add(this.gcStatus);
            this.grid1.Location = new System.Drawing.Point(3, 3);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(639, 250);
            this.grid1.Text = "grid1";
            // 
            // gcId
            // 
            this.gcId.Controls.Add(this.txtId);
            this.gcId.Name = "gcId";
            this.gcId.Text = "ID";
            this.gcId.Width = 100;
            // 
            // txtId
            // 
            this.txtId.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtId.Location = new System.Drawing.Point(2, 1);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(94, 18);
            this.txtId.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtId.Data = this._controller.Branch_.Id;
            // 
            // gcName
            // 
            this.gcName.Controls.Add(this.txtName);
            this.gcName.Name = "gcName";
            this.gcName.Text = "Name";
            this.gcName.Width = 235;
            // 
            // txtName
            // 
            this.txtName.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtName.Location = new System.Drawing.Point(2, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(229, 18);
            this.txtName.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtName.Data = this._controller.Branch_.Name;
            // 
            // gcTelephoneNumber
            // 
            this.gcTelephoneNumber.Controls.Add(this.txtTelephoneNumber);
            this.gcTelephoneNumber.Name = "gcTelephoneNumber";
            this.gcTelephoneNumber.Text = "TelephoneNumber";
            this.gcTelephoneNumber.Width = 145;
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtTelephoneNumber.Location = new System.Drawing.Point(2, 1);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(139, 18);
            this.txtTelephoneNumber.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtTelephoneNumber.Data = this._controller.Branch_.TelephoneNumber;
            // 
            // gcOpenDate
            // 
            this.gcOpenDate.Controls.Add(this.txtOpenDate);
            this.gcOpenDate.Name = "gcOpenDate";
            this.gcOpenDate.Text = "OpenDate";
            this.gcOpenDate.Width = 100;
            // 
            // txtOpenDate
            // 
            this.txtOpenDate.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtOpenDate.Location = new System.Drawing.Point(2, 1);
            this.txtOpenDate.Name = "txtOpenDate";
            this.txtOpenDate.Size = new System.Drawing.Size(94, 18);
            this.txtOpenDate.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtOpenDate.Data = this._controller.Branch_.OpenDate;
            // 
            // gcStatus
            // 
            this.gcStatus.Controls.Add(this.txtStatus);
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.Text = "Status";
            this.gcStatus.Width = 38;
            // 
            // txtStatus
            // 
            this.txtStatus.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtStatus.Location = new System.Drawing.Point(2, 1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(13, 18);
            this.txtStatus.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtStatus.Data = this._controller.Branch_.Status;
            // 
            // CN004ViewBranchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 257);
            this.Controls.Add(this.grid1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN004ViewBranchView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN004ViewBranch";
            this.VerticalExpressionFactor = 1D;
            this.grid1.ResumeLayout(false);
            this.gcId.ResumeLayout(false);
            this.gcName.ResumeLayout(false);
            this.gcTelephoneNumber.ResumeLayout(false);
            this.gcOpenDate.ResumeLayout(false);
            this.gcStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.Grid grid1;
        private Shared.Theme.Controls.GridColumn gcId;
        private Shared.Theme.Controls.TextBox txtId;
        private Shared.Theme.Controls.GridColumn gcName;
        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.GridColumn gcTelephoneNumber;
        private Shared.Theme.Controls.TextBox txtTelephoneNumber;
        private Shared.Theme.Controls.GridColumn gcOpenDate;
        private Shared.Theme.Controls.TextBox txtOpenDate;
        private Shared.Theme.Controls.GridColumn gcStatus;
        private Shared.Theme.Controls.TextBox txtStatus;
    }
}