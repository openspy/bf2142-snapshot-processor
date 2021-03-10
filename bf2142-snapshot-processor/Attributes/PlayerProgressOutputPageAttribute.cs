namespace BF2142.SnapshotProcessor {
    [System.AttributeUsage(System.AttributeTargets.Parameter | System.AttributeTargets.GenericParameter | System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = true)]  
    public class PlayerProgressOutputPageAttribute : System.Attribute  
    {  
        public string PageName {get; set;}
        public string VariableName {get; set;}
        public PlayerProgressOutputPageAttribute()  
        {  
        }
    }
}