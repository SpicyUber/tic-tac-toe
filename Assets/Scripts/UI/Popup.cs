using System;
using System.Collections;
using UnityEngine;

public class Popup : MonoBehaviour
{

    [SerializeField] private float _scaleMultiplier = 1.1f;
    [SerializeField] private float _duration = 0.15f;

    private Vector3 _localScale=Vector3.zero;

    private Coroutine currentRoutine;

    private void OnEnable()
    {
        Pop(GetComponent<RectTransform>());
    }
    private void Pop(RectTransform target)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(PopRoutine(target));
    }

    private IEnumerator PopRoutine(RectTransform target)
    {
        if(_localScale==Vector3.zero)_localScale = target.localScale;
        Vector3 targetScale = _localScale * _scaleMultiplier;

        float half = _duration / 2f;
        float t = 0f;

        
        while (t < half)
        {
            t += Time.unscaledDeltaTime;
            float progress = t / half;
            target.localScale = Vector3.Lerp(_localScale, targetScale, EaseOut(progress));
            yield return null;
        }

        t = 0f;

        
        while (t < half)
        {
            t += Time.unscaledDeltaTime;
            float progress = t / half;
            target.localScale = Vector3.Lerp(targetScale, _localScale, EaseIn(progress));
            yield return null;
        }

        target.localScale = _localScale;
        currentRoutine = null;
    }

    private float EaseOut(float x)
    {
        return 1f - Mathf.Pow(1f - x, 3f);
    }

    private float EaseIn(float x)
    {
        return x * x * x;
    }
}

