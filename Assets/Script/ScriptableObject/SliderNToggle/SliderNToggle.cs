using System;
using UnityEngine;

namespace SGA.UI
{

    [CreateAssetMenu(fileName = "SliderNToggle", menuName = "Scriptable Objects/SliderNToggle")]
    public class SliderNToggle : ScriptableObject
    {
        public float[] sliderValue;
        public bool[] toggleValue;
        public Action<int> toggleChangeAction;
        public Action<int> sliderChangeAction;
        public void SetSize(int sliderSize, int toggleSize)
        {
            sliderValue = new float[sliderSize];
            toggleValue = new bool[toggleSize];
        }

        public void SetSliderValue(int index, float value)
        {
            sliderValue[index] = value;
            sliderChangeAction(index);
        }
        public void SetToggleValue(int index, bool value)
        {
            toggleValue[index] = value;
            toggleChangeAction(index);
        }
    }
}
