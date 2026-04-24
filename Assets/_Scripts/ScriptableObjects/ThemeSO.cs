using UnityEngine;

[CreateAssetMenu(fileName = "ThemeSO", menuName = "Scriptable Objects/ThemeSO")]
public class ThemeSO : ScriptableObject
{
    [SerializeField] public Sprite XSprite;
    [SerializeField] public Sprite OSprite;

    [SerializeField] public Color XColor;
    [SerializeField] public Color OColor;

    public Color GetColor(BoardCellState state) => state switch
    {
        BoardCellState.X => XColor,
        BoardCellState.O => OColor,
        _ => Color.white
    };

    public Sprite GetSprite(BoardCellState state) => state switch
    {
        BoardCellState.X => XSprite,
        BoardCellState.O => OSprite,
        _ => null
    };

    public Color GetColor(int value) 
        => value % 2 == 0 ? XColor : OColor;

    public Sprite GetSprite(int value) 
        => value % 2 == 0 ? XSprite : OSprite;
}
