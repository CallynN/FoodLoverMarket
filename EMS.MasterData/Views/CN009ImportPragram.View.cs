using ENV;
using ENV.Data;
using Firefly.Box;
using Firefly.Box.UI.Advanced;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace EMS.MasterData.Views
{
    partial class CN009ImportPragramView : Shared.Theme.Controls.Form
    {
        #region Columns 
        public String filePath;
        public String fileName;
        public TextColumn V_fileloc = new TextColumn("V_fileloc");
        #endregion

        CN009ImportPragram _controller;
        public CN009ImportPragramView(CN009ImportPragram controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, ButtonClickEventArgs e)
        {
            //openFileDialog1.ShowDialog();
            // _controller.txtFileLocation = openFileDialog1.FileName;
            // BindData(txtFile.Text);


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set filter options for the file dialog
                //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Filter = "Excel Files (*All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Select a File";

                // Show the dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    filePath = openFileDialog.FileName;
                    _controller.V_FileLocation.Value = filePath.ToString();
                    fileName = Path.GetFileName(filePath);
                    _controller.V_FileName.Value = fileName;
                }
            }

        }


        

        private void btnImport_Click(object sender, ButtonClickEventArgs e)
        {
            // Trigger Expand on COntroller

            e.Raise(Command.Expand);

        }
    }
}