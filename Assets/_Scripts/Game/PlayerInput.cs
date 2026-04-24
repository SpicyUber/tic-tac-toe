using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] MatchController _controller;
    private Vector2 _lastPointerPosition = Vector2.zero;
    public void OnTapScreen(InputAction.CallbackContext context) 
    { if (!context.canceled) return;
        RaycastHit hit = new();
        Physics.Raycast(Camera.main.ScreenPointToRay(_lastPointerPosition),out hit, 100f);
        _controller.PlaceOnBoard(hit.point);
    }

    public void OnPointerPosition(InputAction.CallbackContext context) 
    {
        var position = context.ReadValue<Vector2>();
        if (position == _lastPointerPosition) return;
        _lastPointerPosition = position;
    }
}
