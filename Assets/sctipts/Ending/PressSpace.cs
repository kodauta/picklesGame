using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressSpace : MonoBehaviour
{
    public BlinkingText blinkingtext;
    public NextScene nextScene;
    public float displayTime;
    private bool isBlinking;
    private float timeCount;
    private bool isFirstDisplay = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > displayTime)
        {
            if(isFirstDisplay)
            {
                GetComponent<Text>().enabled = true;
                isFirstDisplay = false;

            }
            if(Input.GetButtonDown("Jump"))
            {
                isBlinking = true;
            }
            if(isBlinking)
            {
                blinkingtext.Blinking();
                nextScene.SceneWait();
            }
        }
    }
}
