using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start() => _audioSource = GetComponent<AudioSource>();
    private void Update() => _audioSource.EnforceBGMute();
    
        
    



}
