using System.Collections.Generic;
using UnityEngine;

public class ButtonClickDispatcher : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> handlers;

    public void OnClick()
    {
        foreach (var h in handlers)
        {
            if (h is IClickHandler handler)
                handler.Handle();
        }
    }
}
