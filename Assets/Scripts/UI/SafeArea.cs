using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Vector2Int _lastScreenSize;

    [Header("Margins (Pixels)")]
    [SerializeField] private Vector2 marginMin; // left, bottom
    [SerializeField] private Vector2 marginMax; // right, top

    [Header("Margins (% of screen)")]
    [SerializeField] private Vector2 marginMinPercent; // 0–1 range
    [SerializeField] private Vector2 marginMaxPercent; // 0–1 range

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        ApplyMargins();
    }

    private void Update()
    {
        if (Screen.width != _lastScreenSize.x ||
            Screen.height != _lastScreenSize.y)
        {
            ApplyMargins();
        }
    }

    private void ApplyMargins()
    {
        _lastScreenSize = new Vector2Int(Screen.width, Screen.height);

        float width = Screen.width;
        float height = Screen.height;

        // Combine pixel + percentage margins
        float left = marginMin.x + marginMinPercent.x * width;
        float bottom = marginMin.y + marginMinPercent.y * height;
        float right = marginMax.x + marginMaxPercent.x * width;
        float top = marginMax.y + marginMaxPercent.y * height;

        Rect safeArea = new Rect(
            left,
            bottom,
            width - left - right,
            height - bottom - top
        );

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= width;
        anchorMin.y /= height;
        anchorMax.x /= width;
        anchorMax.y /= height;

        _rectTransform.anchorMin = anchorMin;
        _rectTransform.anchorMax = anchorMax;
    }
}