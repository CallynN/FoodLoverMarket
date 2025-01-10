namespace EMS
{
    /// <summary>FlowUIControllerBase</summary>
    public abstract class FlowUIControllerBase : ENV.FlowUIControllerBase 
    {
        /// <summary>Application that will be used by all inheriting classes</summary>
        public readonly Application Application = EMS.Application.Instance;
        public FlowUIControllerBase()
        {
            setApplication(Application);
        }
    }
}
