using UnityEngine;

public class SFXLabel : ToggleLabel
{
    protected override bool GetConditionValue() => Settings.Instance.IsSFXMuted;
     
     
}
