using TMPro;
using UnityEngine;

public abstract class ToggleLabel : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI _tmp;
    [Header("Strings for forming the label")]
    [SerializeField] string _prefix;
    [SerializeField] string _suffix;
    [SerializeField] string _on, _off;
    void Start() => Refresh();
    
    public void Refresh()
    {
        _tmp.text = _prefix+" "+(GetConditionValue()?_on:_off)+" "+_suffix ;
    }

    
    protected abstract bool GetConditionValue();
}
