using System;
using System.Collections;
using UnityEngine;

public class EndMatchHandler : MonoBehaviour
{
    [SerializeField] PopupSO _gameOverPopup;
    [SerializeField] AudioClip _endMatchSound;
    [SerializeField] float delayInSeconds = 2f;
    public void Handle(MatchData data)
    {
        StopAllCoroutines();
        StartCoroutine(HandleCoroutine(data));
    }

    private IEnumerator HandleCoroutine(MatchData data)
    {
        yield return new WaitForSeconds(delayInSeconds);
        new AudioSource().PlaySFX(_endMatchSound);
        Stats.Instance.Save(data);
        UIManager.Instance.OpenPopup(_gameOverPopup.UniqueName);
        UIManager.Instance.CurrentlyOpen.GetComponent<DisplayMatchData>().Refresh(data);
    }
}
