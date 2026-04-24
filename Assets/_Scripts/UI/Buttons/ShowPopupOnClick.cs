using UnityEngine;

public class ShowPopupOnClick : MonoBehaviour, IClickHandler
{
    [SerializeField] PopupSO _popupSO;
    public void Handle() => UIManager.Instance.OpenPopup(_popupSO.UniqueName);
     
}
