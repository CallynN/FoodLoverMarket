namespace EMS
{
    /// <summary>BusinessProcessBase</summary>
    public abstract class BusinessProcessBase : ENV.BusinessProcessBase 
    {
        /// <summary>Application that will be used by all inheriting classes</summary>
        public readonly Application Application = EMS.Application.Instance;
        public BusinessProcessBase()
        {
            setApplication(Application);
        }
    }
}
