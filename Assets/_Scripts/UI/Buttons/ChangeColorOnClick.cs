using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour,IClickHandler
{
    [SerializeField] Image _buttonImage;
    [SerializeField] Image[] _otherButtonImages;
    [SerializeField] Color _color;

    public void Handle()
    {
        foreach (var image in _otherButtonImages)
        {
            image.color = Color.white;
        }
        if(_buttonImage)
        _buttonImage.color = _color;
    }
}
