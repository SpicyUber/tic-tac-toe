using System;
using UnityEngine;
using UnityEngine.Events;

public class TransitionCameraOnStart : Singleton<TransitionCameraOnStart>
{
    [SerializeField] Transform _position1, _position2;
    [SerializeField] Camera _camera;
    [SerializeField] float _transitionDuration;
    [SerializeField] UnityEvent _transitionEnded;
    private bool _transitioning = true;
    private float _time = 0;

    private void Start() => AssignCamera();

    private void AssignCamera()
    {
        if (!_camera)
            _camera = Camera.main;
    }

    private void Update()=> Transition();

    private void Transition()
    {
        if (!_transitioning) return;
        if (_time > _transitionDuration) 
        {
            
            _camera.transform.rotation = _position2.rotation;
            _camera.transform.position = _position2.position;
            _transitioning = false; 
            _transitionEnded?.Invoke();
            return; 
        }

        _camera.transform.rotation=Quaternion.Slerp(_position1.rotation,_position2.rotation, _time/_transitionDuration);
        _camera.transform.position=Vector3.Lerp(_position1.position, _position2.position, _time / _transitionDuration);
        _time += Time.deltaTime;
    }
}
