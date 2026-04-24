using System;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class MapFOVToScreenWidth : MonoBehaviour
{
    [SerializeField] float _referenceWidth,_referenceHeigth, _referenceFOV;
    [SerializeField]
    [Range(0f, 1f)] float _damping;
    float _lastWidth, _lastHeigth;
    private Camera _camera;

    public void Start()
    {
        SetCamera();
        SaveCurrentWidthAndHeight();
        FovChange();
    }

    private void FovChange()
    {
        _camera.fieldOfView = _referenceFOV* (1+((Screen.height / (float)Screen.width) - (_referenceHeigth / _referenceWidth))*(1-_damping));
    }

    private void SaveCurrentWidthAndHeight()
    {
        _lastWidth = Screen.width;
        _lastHeigth = Screen.height;
    }

    private void SetCamera()
    {
        _camera = GetComponent<Camera>();
    }

    public void Update()
    {
        if (WidthOrHeightChange())
        {
            
            FovChange();
        }
        SaveCurrentWidthAndHeight();
    }

 

    private bool WidthOrHeightChange()
    {
        return _lastHeigth!= Screen.height || _lastWidth!= Screen.width;
    }
}
