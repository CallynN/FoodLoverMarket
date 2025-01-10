
namespace EMS.MasterData.Views
{
    partial class CN007ViewProductsSearchView
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
            this.txtAccept = new EMS.Shared.Theme.Controls.TextBox();
            this.label2 = new EMS.Shared.Theme.Controls.Label();
            this.label3 = new EMS.Shared.Theme.Controls.Label();
            this.textBox1 = new EMS.Shared.Theme.Controls.TextBox();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.label4 = new EMS.Shared.Theme.Controls.Label();
            this.SuspendLayout();
            // 
            // txtAccept
            // 
            this.txtAccept.Location = new System.Drawing.Point(141, 91);
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.Size = new System.Drawing.Size(31, 20);
            this.txtAccept.Data = this._controller.V_Accept;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(68, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Accept(Y/N)";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 11);
            this.label3.Text = "A - Active | D - Deleted ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 20);
            this.textBox1.Data = this._controller.V_Status;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(58, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "Status(A/D)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 11);
            this.label4.Text = "(TAB TO CONTINUE)";
            // 
            // CN007ViewProductsSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 155);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN007ViewProductsSearchView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN007ViewProductsSearch";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.TextBox txtAccept;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.Label label3;
        private Shared.Theme.Controls.TextBox textBox1;
        private Shared.Theme.Controls.Label label1;
        private Shared.Theme.Controls.Label label4;
    }
}