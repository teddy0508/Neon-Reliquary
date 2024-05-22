using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorDown : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] bool isActive;
    [SerializeField] GameObject lasorDown;

    void Update()
    {
        if(isActive)
        {
            Invoke("TurnOff", delay);
        }

        else if (!isActive)
        {
            Invoke("TurnOn", delay);
        }
    }
    void TurnOn()
    {
        lasorDown.SetActive(true);
        isActive = true;
    }
    void TurnOff()
    {
        lasorDown.SetActive(false);
        isActive = false;
    }
}
