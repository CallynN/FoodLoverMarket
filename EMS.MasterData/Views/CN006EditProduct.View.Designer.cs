
namespace EMS.MasterData.Views
{
    partial class CN006EditProductView
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
            this.gcWeightedItem = new EMS.Shared.Theme.Controls.GridColumn();
            this.checkBox1 = new EMS.Shared.Theme.Controls.CheckBox();
            this.gcSuggestedSellingPrice = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtSuggestedSellingPrice = new EMS.Shared.Theme.Controls.TextBox();
            this.gcStatus = new EMS.Shared.Theme.Controls.GridColumn();
            this.txtStatus = new EMS.Shared.Theme.Controls.TextBox();
            this.grid1.SuspendLayout();
            this.gcId.SuspendLayout();
            this.gcName.SuspendLayout();
            this.gcWeightedItem.SuspendLayout();
            this.gcSuggestedSellingPrice.SuspendLayout();
            this.gcStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Controls.Add(this.gcId);
            this.grid1.Controls.Add(this.gcName);
            this.grid1.Controls.Add(this.gcWeightedItem);
            this.grid1.Controls.Add(this.gcSuggestedSellingPrice);
            this.grid1.Controls.Add(this.gcStatus);
            this.grid1.Location = new System.Drawing.Point(3, 3);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(704, 226);
            this.grid1.Text = "grid1";
            // 
            // gcId
            // 
            this.gcId.Controls.Add(this.txtId);
            this.gcId.Name = "gcId";
            this.gcId.TabStop = false;
            this.gcId.Text = "ID";
            this.gcId.Width = 100;
            // 
            // txtId
            // 
            this.txtId.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtId.Location = new System.Drawing.Point(2, 1);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(94, 18);
            this.txtId.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtId.TabStop = false;
            this.txtId.Data = this._controller.Product_.Id;
            // 
            // gcName
            // 
            this.gcName.Controls.Add(this.txtName);
            this.gcName.Name = "gcName";
            this.gcName.Text = "Name";
            this.gcName.Width = 317;
            // 
            // txtName
            // 
            this.txtName.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtName.Location = new System.Drawing.Point(2, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(289, 18);
            this.txtName.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtName.Data = this._controller.Product_.Name;
            // 
            // gcWeightedItem
            // 
            this.gcWeightedItem.Controls.Add(this.checkBox1);
            this.gcWeightedItem.Name = "gcWeightedItem";
            this.gcWeightedItem.Text = "Weighted Item";
            this.gcWeightedItem.Width = 82;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(20, 16);
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.Data = this._controller.Product_.WeightedItem;
            // 
            // gcSuggestedSellingPrice
            // 
            this.gcSuggestedSellingPrice.Controls.Add(this.txtSuggestedSellingPrice);
            this.gcSuggestedSellingPrice.Name = "gcSuggestedSellingPrice";
            this.gcSuggestedSellingPrice.Text = "Suggested Selling Price";
            this.gcSuggestedSellingPrice.Width = 145;
            // 
            // txtSuggestedSellingPrice
            // 
            this.txtSuggestedSellingPrice.AdvancedAnchor = new Firefly.Box.UI.AdvancedAnchor(0, 100, 0, 100);
            this.txtSuggestedSellingPrice.Location = new System.Drawing.Point(2, 1);
            this.txtSuggestedSellingPrice.Name = "txtSuggestedSellingPrice";
            this.txtSuggestedSellingPrice.Size = new System.Drawing.Size(139, 18);
            this.txtSuggestedSellingPrice.Style = Firefly.Box.UI.ControlStyle.Flat;
            this.txtSuggestedSellingPrice.Data = this._controller.Product_.SuggestedSellingPrice;
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
            this.txtStatus.Data = this._controller.Product_.Status;
            // 
            // CN006EditProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 234);
            this.Controls.Add(this.grid1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN006EditProductView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN006EditProduct";
            this.VerticalExpressionFactor = 1D;
            this.grid1.ResumeLayout(false);
            this.gcId.ResumeLayout(false);
            this.gcName.ResumeLayout(false);
            this.gcWeightedItem.ResumeLayout(false);
            this.gcSuggestedSellingPrice.ResumeLayout(false);
            this.gcStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.Grid grid1;
        private Shared.Theme.Controls.GridColumn gcId;
        private Shared.Theme.Controls.TextBox txtId;
        private Shared.Theme.Controls.GridColumn gcName;
        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.GridColumn gcWeightedItem;
        private Shared.Theme.Controls.GridColumn gcSuggestedSellingPrice;
        private Shared.Theme.Controls.TextBox txtSuggestedSellingPrice;
        private Shared.Theme.Controls.GridColumn gcStatus;
        private Shared.Theme.Controls.TextBox txtStatus;
        private Shared.Theme.Controls.CheckBox checkBox1;
    }
}