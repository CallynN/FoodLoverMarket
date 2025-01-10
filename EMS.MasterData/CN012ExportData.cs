using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Globalization;
using System.Xml.Linq;


namespace EMS.MasterData
{
    public class CN012ExportData : BusinessProcessBase
    {
        #region Columns 
        public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
        public readonly TextColumn P_FileType = new TextColumn("P_FileType");
        public readonly TextColumn P_Table = new TextColumn("P_Table");

        #endregion

        public CN012ExportData()
        {
            Title = "CN012 Export Data";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {

            #region Column Selection and USerFlow

            Columns.Add(P_FilePath);
            Columns.Add(P_FileType);
            Columns.Add(P_Table);

            // Flow.Add(() => MessageBox.Show("Test" + P_Table), () => true == true);


            #endregion

        }

        public void Run(TextParameter pP_FilePath, TextParameter pP_FileType, TextParameter pP_Table)
        {
            #region BindParameters
            BindParameter(P_FilePath, pP_FilePath);
            BindParameter(P_FileType, pP_FileType);
            BindParameter(P_Table, pP_Table);
            #endregion
            Execute();
        }

        protected override void OnLoad()
        {
            Exit(ExitTiming.AfterRow);

        }

        protected override void OnLeaveRow()
        {

            // MessageBox.Show("Test" + P_Table +" " + P_FileType +" " + P_FilePath);
            if (P_FileType == "C") // CSV
            {

                // Create<ImportCSV>().Run();
                Cached<ExportCSV>().Run(P_Table, P_FilePath);
            }
            if (P_FileType == "J") // Json
            {
                //Do Validation for that file is Json


                Cached<ExportJson>().Run(P_Table, P_FilePath);
            }
            if (P_FileType == "X") // XML
            {
                // Do validation for the file is XML


                Cached<ExportXML>().Run(P_Table, P_FilePath);
            }



        }




        // Export CSV 
        internal class ExportCSV : BusinessProcessBase
        {
            CN012ExportData _parent;

            #region Models 

            #endregion
            #region Columns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

            #endregion


            public ExportCSV(CN012ExportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {

                
               


            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion
                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);

            }


            protected override void OnEnterRow()
            {

            }

            //Call Import Table Class 
            protected override void OnLeaveRow()
            {


                if (P_Table == "B") // Branch 
                {
                     Cached<CreateBranchCSV>().Run(P_FilePath);
                    //Cached<CN012ExportBranchCsv>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                    Cached<CreateProductCSV>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<CreateBranchProductCSV>().Run(P_FilePath);
                }

            }


            // Create CSV for Branch
            internal class CreateBranchCSV : BusinessProcessBase
            {
                ExportCSV _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion



                public CreateBranchCSV(ExportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {
                    From = Branch_;

                    #region Column Selection and UserFlow
                    Columns.Add(Branch_.Id);
                    Columns.Add(Branch_.Name);
                    Columns.Add(Branch_.TelephoneNumber);
                    Columns.Add(Branch_.OpenDate);
                    Columns.Add(Branch_.Status);


                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath+"\\Branch.csv");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("Id,Name,Telephone,OpenDate");


                }


                protected override void OnStart()
                {
                  
                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    // Format the line to write
                    string line = $"{Branch_.Id.Value},{Branch_.Name.Value.Trim()},{Branch_.TelephoneNumber.Value},{Branch_.OpenDate.Value},";
                    _writer.WriteLine(line);
                }


                protected override void OnEnd()
                {
                   
                }


            }

            // Create CSV for Product
            internal class CreateProductCSV : BusinessProcessBase
            {
                ExportCSV _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateProductCSV(ExportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {


                    From = Product_;

                    #region Column Selection and UserFlow
                    Columns.Add(Product_.Id);
                    Columns.Add(Product_.Name);
                    Columns.Add(Product_.WeightedItem);
                    Columns.Add(Product_.SuggestedSellingPrice);
                    Columns.Add(Product_.Status);


                    #endregion


                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath+"\\Product.csv");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("Id,Name,WeightedItem,SuggestedSellingPrice");

                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    // Format the line to write
                    string line = $"{Product_.Id.Value},{Product_.Name.Value.Trim()},{Product_.WeightedItem.Value},{Product_.SuggestedSellingPrice.Value},";
                    _writer.WriteLine(line);


                }


            }

            // Create CSV for Branch Product 
            internal class CreateBranchProductCSV : BusinessProcessBase
            {
                ExportCSV _parent;

                #region Models 
                public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateBranchProductCSV(ExportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {

                    From = BranchProduct_;

                    #region Column Selection and UserFlow
                    Columns.Add(BranchProduct_.BranchID);
                    Columns.Add(BranchProduct_.ProductID);
                    


                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\BranchProduct.csv");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("BranchID,ProductID");


                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    string line = $"{BranchProduct_.BranchID.Value},{BranchProduct_.ProductID.Value}";
                    _writer.WriteLine(line);



                }


            }



        }

        // Export Json 
        internal class ExportJson : BusinessProcessBase
        {
            CN012ExportData _parent;

            #region Models 

            #endregion
            #region Columns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

            #endregion


            public ExportJson(CN012ExportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {





            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion
                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Save data to Table 
            protected override void OnLeaveRow()
            {
                if (P_Table == "B") // Branch 
                {
                    Cached<CreateBranchJson>().Run(P_FilePath);
                    //Cached<CN012ExportBranchCsv>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                    Cached<CreateProductJson>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<CreateBranchProductJson>().Run(P_FilePath);
                }



            }



            // Create Json for Branch
            internal class CreateBranchJson : BusinessProcessBase
            {
                ExportJson _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion



                public CreateBranchJson(ExportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {
                    From = Branch_;

                    #region Column Selection and UserFlow
                    Columns.Add(Branch_.Id);
                    Columns.Add(Branch_.Name);
                    Columns.Add(Branch_.TelephoneNumber);
                    Columns.Add(Branch_.OpenDate);
                    Columns.Add(Branch_.Status);


                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\Branch.json");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("[");


                }


                protected override void OnStart()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {
                    //string line = $"{Branch_.Id.Value},{Branch_.Name.Value.Trim()},{Branch_.TelephoneNumber.Value},{Branch_.OpenDate.Value},";

                    //_writer.WriteLine(line);

                    // Format the line to write
                    _writer.WriteLine(" {");
                    _writer.WriteLine("    \"ID\": " + Branch_.Id.Value.ToString()+",");
                    _writer.WriteLine("    \"Name\": \"" + Branch_.Name.Value.Trim()+"\",");
                    _writer.WriteLine("    \"TelephoneNumber\": \"" + Branch_.TelephoneNumber.Value.Trim()+"\",");
                    _writer.WriteLine("    \"OpenDate\": \"" + Branch_.OpenDate.Value.ToString()+"\"");
                    _writer.WriteLine(" },");
                    

                }


                protected override void OnEnd()
                {
                    _writer.WriteLine("]");
                }


            }

            // Create CSV for Product
            internal class CreateProductJson : BusinessProcessBase
            {
                ExportJson _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateProductJson(ExportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {


                    From = Product_;

                    #region Column Selection and UserFlow
                    Columns.Add(Product_.Id);
                    Columns.Add(Product_.Name);
                    Columns.Add(Product_.WeightedItem);
                    Columns.Add(Product_.SuggestedSellingPrice);
                    Columns.Add(Product_.Status);


                    #endregion


                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\Product.json");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("[");

                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    // Format the line to write
                    _writer.WriteLine(" {");
                    _writer.WriteLine("    \"ID\": " + Product_.Id.Value.ToString() + ",");
                    _writer.WriteLine("    \"Name\": \"" + Product_.Name.Value.Trim() + "\",");
                    if (Product_.WeightedItem.Value == false)
                    {
                        _writer.WriteLine("    \"WeightedItem\": \"" + "N" + "\",");
                    }
                    else
                    {
                        _writer.WriteLine("    \"WeightedItem\": \"" + "Y" + "\",");
                    }
                   
                    _writer.WriteLine("    \"SuggestedSellingPrice\": " + Product_.SuggestedSellingPrice.Value.ToString() + "");
                    _writer.WriteLine(" },");


                }

                protected override void OnEnd()
                {
                    _writer.WriteLine("]");
                }


            }

            // Create CSV for Branch Product 
            internal class CreateBranchProductJson : BusinessProcessBase
            {
                ExportJson _parent;

                #region Models 
                public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateBranchProductJson(ExportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {

                    From = BranchProduct_;

                    #region Column Selection and UserFlow
                    Columns.Add(BranchProduct_.BranchID);
                    Columns.Add(BranchProduct_.ProductID);



                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\BranchProduct.json");
                    Streams.Add(_writer);

                    // Write the CSV Header
                    _writer.WriteLine("[");


                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    // Format the line to write
                    _writer.WriteLine(" {");
                    _writer.WriteLine("    \"ID\": " + BranchProduct_.BranchID.Value.ToString() + ",");
                    _writer.WriteLine("    \"Name\": " + BranchProduct_.ProductID.Value.ToString() );
                   
                    _writer.WriteLine(" },");



                }


                protected override void OnEnd()
                {
                    _writer.WriteLine("]");
                }


            }



        }

        // Export XML 
        internal class ExportXML : BusinessProcessBase
        {
            CN012ExportData _parent;

            #region Models 

            #endregion
            #region Columns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

            #endregion


            public ExportXML(CN012ExportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {





            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion
                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Save data to Table 
            protected override void OnLeaveRow()
            {
                if (P_Table == "B") // Branch 
                {
                    Cached<CreateBranchXML>().Run(P_FilePath);
                    //Cached<CN012ExportBranchCsv>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                    Cached<CreateProductXML>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<CreateBranchProductXML>().Run(P_FilePath);
                }



            }



            // Create XML for Branch
            internal class CreateBranchXML : BusinessProcessBase
            {
                ExportXML _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion



                public CreateBranchXML(ExportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {
                    From = Branch_;

                    #region Column Selection and UserFlow
                    Columns.Add(Branch_.Id);
                    Columns.Add(Branch_.Name);
                    Columns.Add(Branch_.TelephoneNumber);
                    Columns.Add(Branch_.OpenDate);
                    Columns.Add(Branch_.Status);


                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\Branch.xml");
                    Streams.Add(_writer);

                    // Write the XML Header
                    _writer.WriteLine("<?xml version=\"1.0\"?>");
                    _writer.WriteLine("<Branches>");



                }


                protected override void OnStart()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {
                    
                    // < Branch ID = "1001" Name = "EC CTX MOSSELBAAI" TelephoneNumber = "613 896-7571" OpenDate = "1998/03/22" ></ Branch >
                    // Format the line to write

                    _writer.WriteLine("	<Branch ID=\"" + Branch_.Id.Value.ToString() + "\"" + " Name = \"" + Branch_.Name.Value.Trim() + "\"" + " TelephoneNumber = \"" + Branch_.TelephoneNumber.Value.Trim() + "\"" + " OpenDate = \"" + Branch_.OpenDate.Value.ToString() + "\"" + " ></ Branch >");
                    


                }


                protected override void OnEnd()
                {
                    _writer.WriteLine("</Branches>");
                }


            }

            // Create XML for Product
            internal class CreateProductXML : BusinessProcessBase
            {
                ExportXML _parent;

                #region Models 
                public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateProductXML(ExportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {


                    From = Product_;

                    #region Column Selection and UserFlow
                    Columns.Add(Product_.Id);
                    Columns.Add(Product_.Name);
                    Columns.Add(Product_.WeightedItem);
                    Columns.Add(Product_.SuggestedSellingPrice);
                    Columns.Add(Product_.Status);


                    #endregion


                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\Product.xml");
                    Streams.Add(_writer);

                    _writer.WriteLine("<?xml version=\"1.0\"?>");
                    _writer.WriteLine("<Products>");

                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    // <Product ID="55239" Name="KOSHER 1LT SOUP" WeightedItem="N" SuggestedSellingPrice="113.99"></Product>

                    // Format the line to write
                    if (Product_.WeightedItem.Value == false)
                    {
                        _writer.WriteLine("	<Product ID=\"" + Product_.Id.Value.ToString() + "\"" + " Name =\"" + Product_.Name.Value.Trim() + "\"" + " WeightedItem =\"" + "N" + "\"" + " SuggestedSellingPrice =\"" + Product_.SuggestedSellingPrice.Value.ToString() + "\"" + " ></Product>");

                    }
                    else
                    {
                        _writer.WriteLine("	<Product ID=\"" + Product_.Id.Value.ToString() + "\"" + " Name =\"" + Product_.Name.Value.Trim() + "\"" + " WeightedItem =\"" + "Y" + "\"" + " SuggestedSellingPrice =\"" + Product_.SuggestedSellingPrice.Value.ToString() + "\"" + " ></Product>");

                    }
                    //_writer.WriteLine("	<Product ID=\"" + Product_.Id.Value.ToString() + "\"" + " Name =\"" + Product_.Name.Value.Trim() + "\"" + " WeightedItem =\"" + Product_.WeightedItem.Value.Trim() + "\"" + " OpenDate = \"" + Branch_.OpenDate.Value.ToString() + "\"" + " ></ Branch >");



                }

                protected override void OnEnd()
                {
                    _writer.WriteLine("</Products>");
                }


            }

            // Create XML for Branch Product 
            internal class CreateBranchProductXML : BusinessProcessBase
            {
                ExportXML _parent;

                #region Models 
                public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();

                #endregion
                #region Columns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");

                #endregion
                #region Streams
                ENV.IO.FileWriter _writer;

                #endregion


                public CreateBranchProductXML(ExportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {

                    From = BranchProduct_;

                    #region Column Selection and UserFlow
                    Columns.Add(BranchProduct_.BranchID);
                    Columns.Add(BranchProduct_.ProductID);



                    #endregion



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion
                    Execute();
                }
                protected override void OnLoad()
                {
                    //Exit(ExitTiming.AfterRow);
                    TransactionScope = TransactionScopes.Task;
                    OnDatabaseErrorRetry = true;
                    Activity = Activities.Browse;
                    AllowDelete = false;
                    AllowInsert = false;
                    AllowUpdate = false;
                    AllowUserAbort = true;


                    _writer = new ENV.IO.FileWriter(P_FilePath + "\\BranchProduct.xml");    
                    Streams.Add(_writer);

                    // Write the XML Header
                    _writer.WriteLine("<?xml version=\"1.0\"?>");
                    _writer.WriteLine("<Mappings>");


                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {
                    //<BranchProduct BranchID="1001" ProductID="48798"></BranchProduct>
                    // Format the line to write
                    _writer.WriteLine("	<BranchProduct BranchID=\"" + BranchProduct_.BranchID.Value.ToString() + "\"" + " ProductID=\"" + BranchProduct_.ProductID.Value.ToString() + "\"" + " ></BranchProduct>");



                }


                protected override void OnEnd()
                {
                    _writer.WriteLine("</Mappings>");
                }


            }



        }



    }
}
