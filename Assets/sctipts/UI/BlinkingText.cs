using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public float blinkingSpan;
    private float timeCount;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    public void Blinking()
    {
        timeCount += Time.deltaTime;
        if(timeCount > blinkingSpan)
        {
            if(text.enabled)
            {
                text.enabled = false;
            }
            else
            {
                text.enabled = true;
            }
            timeCount = 0;
        }
    }
}
