using UnityEngine;

public class BGLabel : ToggleLabel
{
    protected override bool GetConditionValue() => Settings.Instance.IsBGMuted;
        
        
    
        
    
}
