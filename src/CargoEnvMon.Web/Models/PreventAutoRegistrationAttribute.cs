namespace CargoEnvMon.Web.Models
{
    public class PreventAutoRegistrationAttribute : Attribute
    {
        public string Reason { get; }

        public PreventAutoRegistrationAttribute()
        {
            Reason = "";
        }

        public PreventAutoRegistrationAttribute(string reason)
        {
            Reason = reason;
        }
    }
}