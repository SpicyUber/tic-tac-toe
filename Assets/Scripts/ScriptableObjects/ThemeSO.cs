using UnityEngine;

[CreateAssetMenu(fileName = "ThemeSO", menuName = "Scriptable Objects/ThemeSO")]
public class ThemeSO : ScriptableObject
{
    [SerializeField] public Sprite XSprite;
    [SerializeField] public Sprite OSprite;
}
