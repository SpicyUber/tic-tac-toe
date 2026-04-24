using UnityEngine;

public class SelectThemeOnClick : MonoBehaviour, IClickHandler
{
    [SerializeField] ThemeSO _theme;
    public void Handle() => Settings.Instance.SetTheme(_theme);
    
}
