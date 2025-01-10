
namespace EMS.MasterData.Views
{
    partial class CN011ExportProgramView
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
            this.btnImport = new EMS.Shared.Theme.Controls.Button();
            this.cbImportTable = new EMS.Shared.Theme.Controls.ComboBox();
            this.cbFileType = new EMS.Shared.Theme.Controls.ComboBox();
            this.label2 = new EMS.Shared.Theme.Controls.Label();
            this.label1 = new EMS.Shared.Theme.Controls.Label();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(166, 174);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 23);
            this.btnImport.Text = "Export";
            this.btnImport.Click += new Firefly.Box.UI.Advanced.ButtonClickEventHandler(this.btnImport_Click);
            this.btnImport.Data = this._controller.B_Export;
            // 
            // cbImportTable
            // 
            this.cbImportTable.DisplayValues = "Branch,Product,ProductBranch";
            this.cbImportTable.Location = new System.Drawing.Point(229, 85);
            this.cbImportTable.Name = "cbImportTable";
            this.cbImportTable.Size = new System.Drawing.Size(188, 21);
            this.cbImportTable.Values = "B,P,R";
            this.cbImportTable.Data = this._controller.V_ImportTable;
            // 
            // cbFileType
            // 
            this.cbFileType.DisplayValues = "CSV,JSON,XML";
            this.cbFileType.Location = new System.Drawing.Point(228, 44);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(188, 21);
            this.cbFileType.Values = "C,J,X";
            this.cbFileType.Data = this._controller.V_FileType;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.Text = "Import To :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.Text = "File Type :";
            // 
            // CN011ExportProgramView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 241);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbImportTable);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.HorizontalExpressionFactor = 1D;
            this.Name = "CN011ExportProgramView";
            this.StartPosition = Firefly.Box.UI.WindowStartPosition.CenterMDI;
            this.Text = "CN011ExportProgram";
            this.VerticalExpressionFactor = 1D;
            this.ResumeLayout(false);

        }

        #endregion

        private Shared.Theme.Controls.Button btnImport;
        private Shared.Theme.Controls.ComboBox cbImportTable;
        private Shared.Theme.Controls.ComboBox cbFileType;
        private Shared.Theme.Controls.Label label2;
        private Shared.Theme.Controls.Label label1;
    }
}