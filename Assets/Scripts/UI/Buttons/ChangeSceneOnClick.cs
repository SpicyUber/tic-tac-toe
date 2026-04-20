using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour, IClickHandler
{
    [SerializeField] SceneAsset _scene;
    public void Handle() => SceneManager.LoadScene(_scene.name);
    
}
