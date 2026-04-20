using UnityEngine;

public static class AudioSourceExtensions
{
    public static void EnforceBGMute(this AudioSource source)
        => source.mute = (Settings.Instance != null && Settings.Instance.IsBGMuted ) ? true : false ;
     
 
}
