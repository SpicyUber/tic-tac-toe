using System.Collections;
using UnityEngine;

public class ScreenShake : Singleton<ScreenShake>
{
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private float _magnitude = 0.2f;

    private Transform _cameraTransform;

    private void Start() => _cameraTransform = Camera.main.transform;

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float t = 0f;
        Vector3 startingPosition = _cameraTransform.localPosition;

        while(t < _duration)
        {
            Vector3 offset = Random.insideUnitSphere * _magnitude * (_duration-t)/_duration;

            _cameraTransform.localPosition = startingPosition + offset;

            t += Time.deltaTime;
            yield return null;
        }

        _cameraTransform.localPosition = startingPosition;
    }
}
