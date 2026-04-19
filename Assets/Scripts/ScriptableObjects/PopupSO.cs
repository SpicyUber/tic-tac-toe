using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PopupSO", menuName = "Scriptable Objects/Popups/PopupSO")]
public class PopupSO : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _uniqueName;

    public void LoadPopupIntoDictionary(Dictionary<string,Popup> dictionary,Transform attachToParent)
    {
        GameObject popupInstance =Instantiate(_prefab,attachToParent);
        var popupComponent = popupInstance.GetComponent<Popup>();
        popupInstance.SetActive(false);
       

        dictionary.Add(_uniqueName, popupComponent);
    }
}
