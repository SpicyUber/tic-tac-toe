using UnityEngine;

public class ToggleSFXOnClick : MonoBehaviour, IClickHandler
{
    public void Handle() => Settings.Instance.ToggleSFX();
    
}
