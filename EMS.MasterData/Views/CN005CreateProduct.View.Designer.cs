
namespace EMS.MasterData.Views
{
    partial class CN005CreateProductView
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
            this.checkBox1 = new EMS.Shared.Theme.Controls.CheckBox();
            this.txtAccept = new EMS.Shared.Theme.Controls.TextBox();
            this.label4 = new EMS.Shared.Theme.Controls.Label();
            this.txtPrice = new EMS.Shared.Theme.Controls.TextBox();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.label2 = new EMS.Shared.Theme.Controls.Label();
            this.txtName = new EMS.Shared.Theme.Controls.TextBox();
            this.label3 = new EMS.Shared.Theme.Controls.Label();
            this.label5 = new EMS.Shared.Theme.Controls.Label();
            this.label6 = new EMS.Shared.Theme.Controls.Label();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(206, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(19, 24);
            this.checkBox1.Data = this._controller.V_ProductWeightedItem;
            // 
            // txtAccept
            // 
            this.txtAccept.Location = new System.Drawing.Point(245, 198);
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.Size = new System.Drawing.Size(31, 20);
            this.txtAccept.Data = this._controller.V_Accept;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(163, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.Text = "Accept(Y/N)";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(206, 92);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.Data = this._controller.V_ProductSuggestedSellingPrice;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.Text = "Product Suggested Price :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(56, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.Text = "Weighted Product :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(206, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(251, 20);
            this.txtName.Data = this._controller.V_ProductName;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(73, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.Text = "Product Name :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(231, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Check for True";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 11);
            this.label6.Text = "(TAB TO CONTINUE)";
            // 
            // CN005CreateProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 254);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN005CreateProductView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN005CreateProduct";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.TextBox txtPrice;
        private Shared.Theme.Controls.Label label1;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.Label label3;
        private Shared.Theme.Controls.CheckBox checkBox1;
        private Shared.Theme.Controls.TextBox txtAccept;
        private Shared.Theme.Controls.Label label4;
        private Shared.Theme.Controls.Label label5;
        private Shared.Theme.Controls.Label label6;
    }
}