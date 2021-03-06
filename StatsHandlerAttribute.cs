namespace BF2142.SnapshotProcessor {
    [System.AttributeUsage(System.AttributeTargets.Parameter | System.AttributeTargets.GenericParameter | System.AttributeTargets.Field | System.AttributeTargets.Property)]  
    public class StatsHandlerAttribute : System.Attribute  
    {  
        public enum EStatsHandlerType {
            HandlerType_Increment,
            HandlerType_GreaterEqual,
            HandlerType_Max,
            HandlerType_Set,
            HandlerType_Computed,
            HandlerType_Ignore
        }
    
        public EStatsHandlerType HandlerType {get; set; }
        public StatsHandlerAttribute()  
        {  
        }  
        public bool IsIncrement { get { return HandlerType == EStatsHandlerType.HandlerType_Increment; } }
        public bool IsGreaterEqual { get { return HandlerType == EStatsHandlerType.HandlerType_GreaterEqual; } }
        public bool IsSet { get { return HandlerType == EStatsHandlerType.HandlerType_Set; } }
        public bool IsComputed { get { return HandlerType == EStatsHandlerType.HandlerType_Computed; }}
    }  
}