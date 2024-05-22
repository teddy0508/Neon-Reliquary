using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasorUp : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] bool isActive;
    [SerializeField] GameObject lasorUp;

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
        lasorUp.SetActive(true);
        isActive = true;
    }
    void TurnOff()
    {
        lasorUp.SetActive(false);
        isActive = false;
    }
}
