
namespace EMS.MasterData.Views
{
    partial class CN001CreateBranchView
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
            this.calender1 = new EMS.Shared.Theme.Controls.Calender();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.txtTell = new EMS.Shared.Theme.Controls.TextBox();
            this.lblTele = new EMS.Shared.Theme.Controls.Label();
            this.txtName = new EMS.Shared.Theme.Controls.TextBox();
            this.lblname = new EMS.Shared.Theme.Controls.Label();
            this.label4 = new EMS.Shared.Theme.Controls.Label();
            this.SuspendLayout();
            // 
            // txtAccept
            // 
            this.txtAccept.Location = new System.Drawing.Point(228, 178);
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.Size = new System.Drawing.Size(31, 20);
            this.txtAccept.Data = this._controller.V_Accept;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(146, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "Accept(Y/N)";
            // 
            // calender1
            // 
            this.calender1.Location = new System.Drawing.Point(126, 103);
            this.calender1.Name = "calender1";
            this.calender1.Size = new System.Drawing.Size(100, 20);
            this.calender1.Data = this._controller.V_OpenDate;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.Text = "Open Date :";
            // 
            // txtTell
            // 
            this.txtTell.Location = new System.Drawing.Point(126, 66);
            this.txtTell.Name = "txtTell";
            this.txtTell.Size = new System.Drawing.Size(100, 20);
            this.txtTell.Data = this._controller.V_Telephone;
            // 
            // lblTele
            // 
            this.lblTele.Location = new System.Drawing.Point(20, 66);
            this.lblTele.Name = "lblTele";
            this.lblTele.Size = new System.Drawing.Size(100, 20);
            this.lblTele.Text = "Telephone Number :";
            this.lblTele.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(275, 20);
            this.txtName.Data = this._controller.V_BranchName;
            // 
            // lblname
            // 
            this.lblname.Location = new System.Drawing.Point(33, 31);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(87, 20);
            this.lblname.Text = "Name Of Branch :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 11);
            this.label4.Text = "(TAB TO CONTINUE)";
            // 
            // CN001CreateBranchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 235);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calender1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTell);
            this.Controls.Add(this.lblTele);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblname);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN001CreateBranchView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN001CreateBranch";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.TextBox txtName;
        private Shared.Theme.Controls.TextBox txtTell;
        private Shared.Theme.Controls.Label lblname;
        private Shared.Theme.Controls.Label lblTele;
        private Shared.Theme.Controls.Calender calender1;
        private Shared.Theme.Controls.Label label1;
        private Shared.Theme.Controls.TextBox txtAccept;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.Label label4;
    }
}