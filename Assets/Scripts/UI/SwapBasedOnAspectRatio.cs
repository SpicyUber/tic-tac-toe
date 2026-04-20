using UnityEngine;

public class SwapBasedOnAspectRatio : MonoBehaviour
{
 
    [SerializeField] private GameObject _wideObject;
    [SerializeField] private GameObject _tallObject;

    private bool? _lastIsWide = null;

    void Start()
    {
        Apply();
    }

    void Update()
    {
        // Only re-evaluate if something actually changed
        bool isWide = Screen.width > Screen.height;

        if (_lastIsWide == null || _lastIsWide != isWide)
        {
            Apply();
        }
    }

    private void Apply()
    {
        bool isWide = Screen.width > Screen.height;
        _lastIsWide = isWide;

        if (_wideObject != null)
            _wideObject.SetActive(isWide);

        if (_tallObject != null)
            _tallObject.SetActive(!isWide);
    }
 
}
