using UnityEngine;

public class ClosePopupOnClick : MonoBehaviour, IClickHandler
{
  


    public void Handle() => UIManager.Instance.CloseCurrent();
}
