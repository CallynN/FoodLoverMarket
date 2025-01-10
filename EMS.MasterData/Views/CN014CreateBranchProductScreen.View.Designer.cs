
namespace EMS.MasterData.Views
{
    partial class CN014CreateBranchProductScreenView
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
            this.gcId1 = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtId1 = new EMS.Shared.Theme.Controls.TextBox();
            this.gcName = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtName = new EMS.Shared.Theme.Controls.TextBox();
            this.gcId = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtId = new EMS.Shared.Theme.Controls.TextBox();
            this.gcName1 = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtName1 = new EMS.Shared.Theme.Controls.TextBox();
            this.grid1.SuspendLayout();
            this.gcId1.SuspendLayout();
            this.gcName.SuspendLayout();
            this.gcId.SuspendLayout();
            this.gcName1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Controls.Add(this.gcId1);
            this.grid1.Controls.Add(this.gcName);
            this.grid1.Controls.Add(this.gcId);
            this.grid1.Controls.Add(this.gcName1);
            this.grid1.Location = new System.Drawing.Point(20, 17);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(836, 327);
            this.grid1.Text = "grid1";
            // 
            // gcId1
            // 
            this.gcId1.Controls.Add(this.txtId1);
            this.gcId1.Name = "gcId1";
            this.gcId1.Text = "Branch";
            // 
            // txtId1
            // 
            this.txtId1.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtId1.Location = new System.Drawing.Point(2, 1);
            this.txtId1.Name = "txtId1";
            this.txtId1.ReadOnly = true;
            this.txtId1.Size = new System.Drawing.Size(114, 21);
            this.txtId1.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtId1.TabStop = false;
            this.txtId1.Data = this._controller.Branch_.Id;
            // 
            // gcName
            // 
            this.gcName.Controls.Add(this.txtName);
            this.gcName.Name = "gcName";
            this.gcName.Text = "Branch Name";
            this.gcName.Width = 285;
            // 
            // txtName
            // 
            this.txtName.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtName.Location = new System.Drawing.Point(2, 1);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(279, 21);
            this.txtName.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtName.TabStop = false;
            this.txtName.Data = this._controller.Branch_.Name;
            // 
            // gcId
            // 
            this.gcId.Controls.Add(this.txtId);
            this.gcId.Name = "gcId";
            this.gcId.Text = "Product ID";
            // 
            // txtId
            // 
            this.txtId.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtId.Location = new System.Drawing.Point(2, 1);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(114, 21);
            this.txtId.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtId.Data = this._controller.Product_.Id;
            // 
            // gcName1
            // 
            this.gcName1.Controls.Add(this.txtName1);
            this.gcName1.Name = "gcName1";
            this.gcName1.Text = "Product Name";
            this.gcName1.Width = 285;
            // 
            // txtName1
            // 
            this.txtName1.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtName1.Location = new System.Drawing.Point(2, 1);
            this.txtName1.Name = "txtName1";
            this.txtName1.ReadOnly = true;
            this.txtName1.Size = new System.Drawing.Size(279, 21);
            this.txtName1.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtName1.TabStop = false;
            this.txtName1.Data = this._controller.NProduct_.Name;
            // 
            // CN014CreateBranchProductScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 371);
            this.Controls.Add(this.grid1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN014CreateBranchProductScreenView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN014CreateEditBranchProductScreen";
            this.VerticalExpressionFactor = 1D;
            this.grid1.ResumeLayout(false);
            this.gcId1.ResumeLayout(false);
            this.gcName.ResumeLayout(false);
            this.gcId.ResumeLayout(false);
            this.gcName1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.Grid grid1;
        private Shared.Theme.Controls.GridColumn gcName;
        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.GridColumn gcId;
        private Shared.Theme.Controls.TextBox txtId;
        private Shared.Theme.Controls.GridColumn gcName1;
        private Shared.Theme.Controls.TextBox txtName1;
        private Shared.Theme.Controls.GridColumn gcId1;
        private Shared.Theme.Controls.TextBox txtId1;
    }
}