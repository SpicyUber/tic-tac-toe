using UnityEngine;

public class QuitApplicationOnClick :MonoBehaviour, IClickHandler
{
    public void Handle()=>Application.Quit();
   
}
