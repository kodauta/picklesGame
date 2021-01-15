using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutCamera : MonoBehaviour
{
    public float changeSpeed;
    public float intervalTime; //フェードインアウトの間
    private StatusCounter statusCounter;
    public bool isFadeOut;
    public bool isFadeIn;
    public bool fadeBack = true;
    private bool isTimeCount;
    private float timeCount;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image =  GetComponent<Image>();
        image.enabled = true;
        image.color = new Color (0, 0, 0, 1.0f);
        statusCounter = GameObject.Find("Canvas").GetComponent<StatusCounter>();
        isFadeIn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFadeIn)
        {
            FadeIn();
        }
        if(isFadeOut)
        {
            FadeOut();
        }
        if(isTimeCount)
        {
            timeCount += Time.deltaTime;
            if(timeCount > intervalTime)
            {
                if(fadeBack)
                {
                    isFadeIn = true;
                }
                isTimeCount = false;
                timeCount = 0;
            }
        }
    }
    void FadeIn()
    { 
        if(image.color.a > 0)
        {
            isFadeOut = false;
            image.color -= new Color(0, 0, 0, changeSpeed); 
        }
        else
        {
            isFadeIn = false;
        }
    }

    void FadeOut()
    {
        if(image.color.a < 1)
        {
            image.color += new Color(0, 0, 0, changeSpeed); 
        }
        else
        {
            isFadeOut = false;
            isTimeCount = true;
        }
    }
}
