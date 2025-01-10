namespace EMS
{
    class ApplicationEntities : ENV.ApplicationEntityCollection 
    {
        public ApplicationEntities()
        {

            // Add Here To View Table In Information Screen 
            // Example : 
            //Add(1, typeof(Models.Contacts.Address));
            Add(1, typeof(Models.MasterData.Branch));
            Add(2, typeof(Models.MasterData.Product));
            Add(3, typeof(Models.MasterData.BranchProduct));



        }
    }
}
