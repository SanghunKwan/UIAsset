using UnityEngine;

[CreateAssetMenu(fileName = "SliderValue", menuName = "Scriptable Objects/SliderValue")]
public class SliderValue : ScriptableObject
{
    float m_value;
    public float Value
    {
        get { return m_value; }
    }
    public void SetValue(float value)
    {
        m_value = value;
    }
}
