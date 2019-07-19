using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float Countdown;
    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Countdown);
        gameObject.SetActive(false);
    }
}
