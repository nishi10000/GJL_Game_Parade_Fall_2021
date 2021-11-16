using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarTimer : MonoBehaviour
{
    private bool timerStart;
    private bool timerFinished;
    private float totalTime;
    public Text UItext;

    void Start()
    {
        timerStart = false;
        timerFinished = false;
        totalTime = 0;
    }

    void FixedUpdate()
    {
        if (timerStart == true && timerFinished == false)
            totalTime += Time.deltaTime;

        UItext.text = totalTime.ToString("F2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StartLine")
        {
            if (timerStart == false)
                timerStart = true;
            else
                timerFinished = true;
        }

    }
}