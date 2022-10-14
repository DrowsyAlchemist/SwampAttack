using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected int MaxValue;

    protected virtual void OnValueChanged(int value)
    {
        Slider.value = (float)value / MaxValue;
    }
    
    protected virtual void OnValueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
