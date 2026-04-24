using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonPersistent<UIManager>
{
    [Header("Popup SOs")]
    [SerializeField] PopupSO[] _popupSOs;

    [Header("Attach Popups To")]
    [SerializeField] Transform _transform;

    public Popup CurrentlyOpen => _currentlyOpen;

    private Dictionary<string, Popup> _popupDictionary;
    private Popup _currentlyOpen;
    private Popup _default;

    private void OnEnable() => LoadPopups();

    private void LoadPopups()
    {
        

        _popupDictionary = new Dictionary<string, Popup>();
        
        foreach (PopupSO so in _popupSOs) 
        { 
            so.LoadPopupIntoDictionary(_popupDictionary, attachToParent: _transform);

        }

    }

   
    public void SetDefault(Popup popup) { _default = popup;
        CloseCurrent();
        _currentlyOpen = _default;
    }

    private void OpenDefault() => OpenPopup(_default);

    public void CloseCurrent() => ClosePopup(_currentlyOpen);

    public void ClosePopup(string name) => ClosePopup(_popupDictionary[name]);

    public void OpenPopup(string name) => OpenPopup(_popupDictionary[name]);


    public void ClosePopup(Popup popup)
    {
        if (popup && popup.gameObject.activeInHierarchy) {
            
            popup.gameObject.SetActive(false);
            
            if(popup!=_default)
            OpenPopup(_default);
        }
    }
    private void OpenPopup(Popup popup)
    {
        CloseCurrent();
        if (!popup) return;
        popup.gameObject.SetActive(true);
        _currentlyOpen = popup;
    }

    public void ClearDefault()
    {
        _default = null;
    }
}
