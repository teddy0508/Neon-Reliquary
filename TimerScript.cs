using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timerValue;
    [SerializeField] float timeToComplete;
    [SerializeField] Image timer;
    void Start() 
    {
        timer = GetComponent<Image>();
        timerValue = timeToComplete;
    }

    void Update()
    {
        timerValue -= Time.deltaTime;
        timer.fillAmount = timerValue / timeToComplete;
    }
}
