using UnityEngine;

public class Settings : SingletonPersistent<Settings>
{
    public bool IsSFXMuted => _muteSFX;
    public bool IsBGMuted => _muteBG;

    public ThemeSO Theme => _theme;

    private ThemeSO _theme;

    private bool _muteSFX, _muteBG;
    public void ToggleSFX()
    {
        _muteSFX = !_muteSFX;
    }

    public void ToggleBG()
    {
        _muteBG = !_muteBG;
    }

    public void SetTheme(ThemeSO theme)
    {
        _theme = theme;
    }


}
