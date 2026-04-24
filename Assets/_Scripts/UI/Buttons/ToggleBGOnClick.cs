using UnityEngine;

public class ToggleBGOnClick : MonoBehaviour, IClickHandler
{
    public void Handle() => Settings.Instance.ToggleBG();

}
