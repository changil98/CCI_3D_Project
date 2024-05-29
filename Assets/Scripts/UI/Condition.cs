using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    PlayerController controller;

    public float nowValue;
    public float maxValue;
    public float addValue;
    public float subtractValue;
    public Image uiBar;

    void Start()
    {
        nowValue = maxValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPecentage();
    }

    float GetPecentage()
    {
        return nowValue / maxValue;
    }

    public void Add(float value)
    {
        nowValue = Mathf.Min(nowValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        nowValue = Mathf.Max(nowValue - value, 0);
    }
}
