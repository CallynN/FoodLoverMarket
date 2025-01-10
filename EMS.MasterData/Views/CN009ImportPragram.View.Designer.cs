
namespace EMS.MasterData.Views
{
    partial class CN009ImportPragramView
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
            this.cbFileType = new EMS.Shared.Theme.Controls.ComboBox();
            this.cbImportTable = new EMS.Shared.Theme.Controls.ComboBox();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.label2 = new EMS.Shared.Theme.Controls.Label();
            this.btnImport = new EMS.Shared.Theme.Controls.Button();
            this.txtFileLocation = new EMS.Shared.Theme.Controls.TextBox();
            this.label3 = new EMS.Shared.Theme.Controls.Label();
            this.btnOpen = new EMS.Shared.Theme.Controls.Button();
            this.SuspendLayout();
            // 
            // cbFileType
            // 
            this.cbFileType.DisplayValues = "CSV,JSON,XML";
            this.cbFileType.Location = new System.Drawing.Point(231, 144);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(188, 21);
            this.cbFileType.Values = "C,J,X";
            this.cbFileType.Data = this._controller.V_FileType;
            // 
            // cbImportTable
            // 
            this.cbImportTable.DisplayValues = "Branch,Product,ProductBranch";
            this.cbImportTable.Location = new System.Drawing.Point(232, 185);
            this.cbImportTable.Name = "cbImportTable";
            this.cbImportTable.Size = new System.Drawing.Size(188, 21);
            this.cbImportTable.Values = "B,P,R";
            this.cbImportTable.Data = this._controller.V_ImportTable;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(44, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.Text = "File Type :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(44, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.Text = "Import To :";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(176, 272);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 23);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new Firefly.Box.UI.Advanced.ButtonClickEventHandler(this.btnImport_Click);
            this.btnImport.Data = this._controller.B_Import;
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(44, 53);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.ReadOnly = true;
            this.txtFileLocation.Size = new System.Drawing.Size(375, 22);
            this.txtFileLocation.TabStop = false;
            this.txtFileLocation.Data = this._controller.V_FileLocation;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(44, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.Text = "File Location :";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(344, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.Text = "OPEN";
            this.btnOpen.Click += new Firefly.Box.UI.Advanced.ButtonClickEventHandler(this.btnOpen_Click);
            this.btnOpen.Data = this._controller.B_Open;
            // 
            // CN009ImportPragramView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 324);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbImportTable);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.label3);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN009ImportPragramView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN009ImportPragram";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.ComboBox cbFileType;
        private Shared.Theme.Controls.ComboBox cbImportTable;
        private Shared.Theme.Controls.Label label1;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.Button btnImport;
        private Shared.Theme.Controls.TextBox txtFileLocation;
        private Shared.Theme.Controls.Label label3;
        private Shared.Theme.Controls.Button btnOpen;
    }
}