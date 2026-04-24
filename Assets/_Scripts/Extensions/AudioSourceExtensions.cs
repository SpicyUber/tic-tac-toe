using UnityEngine;

public static class AudioSourceExtensions
{
    public static void EnforceBGMute(this AudioSource source)
        => source.mute = (Settings.Instance != null && Settings.Instance.IsBGMuted ) ? true : false ;
    
    public static void PlaySFX( this AudioSource source, AudioClip soundEffect) 
    {
        if (!Settings.Instance || Settings.Instance.IsSFXMuted)
            return;
        AudioSource.PlayClipAtPoint(soundEffect, Vector3.zero);
    }
 
}
