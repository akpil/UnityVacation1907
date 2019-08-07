using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    public Text PointText;
    public Image Gauge;

    public void ShowGauge(int current, int max)
    {
        float percent = (float)current / max;
        Gauge.fillAmount = percent;
        PointText.text = current.ToString() + "/" + max.ToString();
    }
}
