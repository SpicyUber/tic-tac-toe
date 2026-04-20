using UnityEngine;

public class PlaySFXOnClick : MonoBehaviour, IClickHandler
{
    public AudioClip SFX;
    public void Handle()
    {
        if (Settings.Instance.IsSFXMuted)
            return;
        AudioSource.PlayClipAtPoint(SFX,Vector3.zero);
    }
}
