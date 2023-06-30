using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximumValue;
    public int currentValue;
    public Image mask;

    void Start()
    {

    }

    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)currentValue / (float)maximumValue;
        mask.fillAmount = fillAmount;
    }
}
