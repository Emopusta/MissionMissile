using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SetFuel(int fuel)
    {
        slider.value = (float)fuel/10000;
        Debug.Log(slider.value);
    }
    
}
