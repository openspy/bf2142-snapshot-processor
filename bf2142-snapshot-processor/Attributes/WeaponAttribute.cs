namespace BF2142.SnapshotProcessor {
    [System.AttributeUsage(System.AttributeTargets.Parameter | System.AttributeTargets.GenericParameter | System.AttributeTargets.Field | System.AttributeTargets.Property)]  
    public class WeaponAttribute : System.Attribute  
    {  
        public int WeaponId {get; set;}
        public WeaponAttribute()  
        {  
        }
    }  
}