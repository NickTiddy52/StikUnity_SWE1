using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorLerper : MonoBehaviour
{
    public float period = 1.0f;
    public float phase = 1.0f;
    public Color startColor;
    public Color endColor;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Mathf.Repeat(Time.time - startTime, period) / period;

        if (pos < .5f) {
            GetComponent<TextMeshProUGUI>().color 
                = Color32.Lerp(startColor, endColor, pos * 2f);   //defines ascending edge of triangle wave
        }
        else {
            GetComponent<TextMeshProUGUI>().color 
                = Color32.Lerp(endColor, startColor, (pos - .5f) * 2f); //defines descending edge of triangle wave
        }
    }
}
