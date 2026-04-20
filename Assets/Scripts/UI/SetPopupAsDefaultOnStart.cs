using UnityEngine;

public class SetPopupAsDefaultOnStart : MonoBehaviour
{
    [SerializeField] Popup _popup;
    void Start()=>UIManager.Instance.SetDefault(_popup);
   

    
}
