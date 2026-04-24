using UnityEngine;

[CreateAssetMenu(fileName = "PlaceEffectSO", menuName = "Scriptable Objects/PlaceEffectSO")]
public class PlaceEffectSO : ScriptableObject
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _startColor, _endColor;
    [SerializeField] private AudioClip _startSound, _endSound;
    [SerializeField] private GameObject _startParticlePrefab, _endParticlePrefab;

    public float DurationInSeconds => _duration;

    public Color StartColor => _startColor;
    public Color EndColor => _endColor;

    public AudioClip StartSound => _startSound;
    public AudioClip EndSound => _endSound;

    public GameObject StartParticlePrefab => _startParticlePrefab;
    public GameObject EndParticlePrefab => _endParticlePrefab;
}
