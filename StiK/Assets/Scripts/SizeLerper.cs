using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SizeLerper : MonoBehaviour
{
    public float period = 1.0f;
    public float phase = 1.0f;
    public float startSize;
    public float endSize;
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
            GetComponent<TextMeshProUGUI>().fontSize
                = Mathf.Lerp(startSize, endSize, pos * 2f);   //defines ascending edge of triangle wave
        }
        else {
            GetComponent<TextMeshProUGUI>().fontSize
                = Mathf.Lerp(endSize, startSize, (pos - .5f) * 2f); //defines descending edge of triangle wave
        }
    }
}
