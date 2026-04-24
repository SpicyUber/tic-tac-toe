using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour, IClickHandler
{
    [SerializeField] SceneAsset _scene;
    [SerializeField] Popup _popupToClose;
     
    
    private Button _button;

    public void Start() => _button = GetComponent<Button>();
    public void Handle()
    {
        if (_button)
            _button.interactable = false;

        float dropDurationInSeconds = _popupToClose.Drop();

        StartCoroutine(LoadSceneAfterDelay(dropDurationInSeconds-0.05f));
        
    }

    private IEnumerator LoadSceneAfterDelay(float delayInSeconds)
    { 

        UIManager.Instance.ClearDefault();
        yield return new WaitForSeconds(delayInSeconds);
        _button.interactable = true;
        SceneManager.LoadScene(_scene.name);
        
        UIManager.Instance.ClosePopup(_popupToClose);
    }
  
}
