using UnityEngine;

public class PlaySFXOnClick : MonoBehaviour, IClickHandler
{
    public AudioClip SFX;
    public void Handle() => new AudioSource().PlaySFX(SFX);



}
