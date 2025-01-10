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
using System.IO;

namespace EMS.MasterData.Views
{
    partial class CN011ExportProgramView : Shared.Theme.Controls.Form
    {
        #region Columns 
        public String filePath;
        public TextColumn V_fileloc = new TextColumn("V_fileloc");
        #endregion

        CN011ExportProgram _controller;
        public CN011ExportProgramView(CN011ExportProgram controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void btnImport_Click(object sender, ButtonClickEventArgs e)
        {

            // Create a new instance of the FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder to save your file";
                folderBrowserDialog.ShowNewFolderButton = true; 

                // Show the dialog and check if the user selected a folder
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string folderPath = folderBrowserDialog.SelectedPath;

                     //MessageBox.Show($"File will be saved at: {filePath}", "File Path Selected");
                    _controller.V_FileLocation.Value = folderPath;

                }
                else
                {
                    MessageBox.Show("No folder selected.", "Operation Cancelled");
                }
            }


            e.Raise(Command.Expand);


        }
    }
}