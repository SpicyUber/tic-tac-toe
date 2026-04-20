using UnityEngine;

public class Stats : SingletonPersistent<Stats>
{
    [SerializeField] StatsSO _keywords;
    public float AverageGamesDuration
    {
        get
        {
            if (_gamesPlayed <= 0) return 0;
            return _totalPlayTime / _gamesPlayed;
        }

    }
    public int Player1WinCount
    {
        get { return PlayerPrefs.GetInt(_keywords.Player1WinCount); }
        private set { PlayerPrefs.SetInt(_keywords.Player1WinCount, value); }
    }

    public int Player2WinCount
    {
        get { return PlayerPrefs.GetInt(_keywords.Player2WinCount); }
        private set { PlayerPrefs.SetInt(_keywords.Player2WinCount, value); }
    }


    public int DrawCount
    {
        get { return PlayerPrefs.GetInt(_keywords.DrawCount); }
        private set { PlayerPrefs.SetInt(_keywords.DrawCount, value); }
    }

    private int _gamesPlayed
    {
        get { return PlayerPrefs.GetInt(_keywords.GamesPlayed); }
        set { PlayerPrefs.SetInt(_keywords.GamesPlayed, value); }
    }

    private float _totalPlayTime
    {
        get { return PlayerPrefs.GetFloat(_keywords.TotalPlayTime); }
        set { PlayerPrefs.SetFloat(_keywords.TotalPlayTime, value); }
    }
    public void Save(MatchData matchData) {
        switch (matchData.result)
        {
            case MatchResult.P1WIN:
                Player1WinCount++;
                break;
                case MatchResult.P2WIN:
                Player2WinCount++;
                break ;
            case MatchResult.DRAW:
                DrawCount++;
                break;
        }

        _totalPlayTime += matchData.durationInSeconds;

    }
}
