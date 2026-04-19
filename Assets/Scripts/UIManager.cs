using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonPersistent<UIManager>
{
    [SerializeField] PopupSO[] _popupSOs;

    private Dictionary<string, Popup> _popupDictionary;
    private Popup _currentlyOpen;

    private void Start() => LoadPopups();

    private void LoadPopups()
    {
        _popupDictionary = new Dictionary<string, Popup>();

        foreach (PopupSO so in _popupSOs) 
        { 
            so.LoadPopupIntoDictionary(_popupDictionary, attachToParent: this.transform);

        }

    }

    public void CloseCurrent() => ClosePopup(_currentlyOpen);

    public void ClosePopup(string name) => ClosePopup(_popupDictionary[name]);

    public void OpenPopup(string name) => OpenPopup(_popupDictionary[name]);

    private void ClosePopup(Popup popup)
    {
        if (popup && popup.gameObject.activeInHierarchy)
            popup.gameObject.SetActive(false);
    }
    private void OpenPopup(Popup popup)
    {
        CloseCurrent();
        popup?.gameObject.SetActive(true);
    }
}
