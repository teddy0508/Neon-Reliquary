using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterScript : MonoBehaviour
{
    public static float counter;
    TextMeshProUGUI counterText;
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        counterText.text = counter + " / 3";
    }
}
