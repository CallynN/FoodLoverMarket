using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using Firefly.Box.Flow;

namespace EMS.MasterData
{
    public class CN009ImportPragram : FlowUIControllerBase, ICN009ImportProgram
    {
        #region Models 

        #endregion
        #region Columns
        public readonly TextColumn B_Open = new TextColumn("B_Open");
        public readonly TextColumn V_FileType = new TextColumn("V_FileType", "U") { InputRange = "C,J,X" };
        public readonly TextColumn V_ImportTable = new TextColumn("V_ImportTable", "U") { InputRange = "B,P,R"};
        public  TextColumn V_FileLocation = new TextColumn("V_FileLocation");
        public readonly TextColumn B_Import = new TextColumn("B_Import");
        public readonly TextColumn V_FileName = new TextColumn("V_FileName");

        #endregion

        public CN009ImportPragram()
        {
            Title = "CN009 Import Program";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {

            #region Column Selection and UserFlow
            // Columns.Add(B_Open).BindValue("OPEN");
            Columns.Add(B_Open).BindValue(() => "OPEN");
            Columns.Add(V_FileLocation);
            Columns.Add(V_FileType);
            Columns.Add(V_ImportTable);

            Columns.Add(B_Import).BindValue(() => "IMPORT");
            Flow.StartBlock(FlowMode.ExpandAfter);
            #region Block
            {
                Debug.WriteLine(V_FileType + " " + V_ImportTable + " " + V_FileLocation);
                Flow.Add<CN010ImportData>(c => c.Run(V_FileLocation, V_FileType, V_ImportTable), FlowMode.Tab);
                Debug.WriteLine(V_FileType + " " + V_ImportTable + " " + V_FileLocation);
                //System.Windows.Forms.MessageBox.Show("Impot Completed");
                Flow.Add(() => System.Windows.Forms.MessageBox.Show("!! Import Completed !!"), () => true == true);

            }
            Flow.EndBlock();
            #endregion



            #endregion


        }

        public void Run()
        {
            Execute();
        }

        protected override void OnLoad()
        {
            View = () => new Views.CN009ImportPragramView(this);
        }


        protected override void OnLeaveRow()
        {
            Debug.WriteLine(V_FileLocation);
        }
    }
}