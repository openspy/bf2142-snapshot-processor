namespace BF2142.SnapshotProcessor {
    [System.AttributeUsage(System.AttributeTargets.Parameter | System.AttributeTargets.GenericParameter | System.AttributeTargets.Field | System.AttributeTargets.Property)]  
    public class VehicleAttribute : System.Attribute  
    {  
        public int VehicleId {get; set;}
        public VehicleAttribute()  
        {  
        }
    }  
}