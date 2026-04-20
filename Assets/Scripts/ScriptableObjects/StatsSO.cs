using UnityEngine;

[CreateAssetMenu(fileName = "StatsSO", menuName = "Scriptable Objects/StatsSO")]
public class StatsSO : ScriptableObject
{
    [SerializeField] public string GamesPlayed,Player1WinCount,Player2WinCount,DrawCount, TotalPlayTime;  
}
