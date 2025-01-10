
namespace EMS.MasterData.Views
{
    partial class CN013CreateBranchProductView
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
            this.label2 = new EMS.Shared.Theme.Controls.Label();
            this.textBox2 = new EMS.Shared.Theme.Controls.TextBox();
            this.textBox1 = new EMS.Shared.Theme.Controls.TextBox();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.label3 = new EMS.Shared.Theme.Controls.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(183, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 22);
            this.label2.Text = "(Tab To Continue)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(192, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(267, 22);
            this.textBox2.TabStop = false;
            this.textBox2.Data = this._controller.Branch_.Name;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 22);
            this.textBox1.Data = this._controller.V_Branch;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.Text = "Enter Branch :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(179, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 22);
            this.label3.Text = "(F5 to Select Branch)";
            // 
            // CN013CreateBranchProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 153);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN013CreateBranchProductView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN013CreateEditBranchProduct";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.TextBox textBox1;
        private Shared.Theme.Controls.Label label1;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.TextBox textBox2;
        private Shared.Theme.Controls.Label label3;
    }
}