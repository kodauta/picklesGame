using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextSelect : MonoBehaviour
{
    public int textNum = 0;
    private float timeCount;
    private Vector3 thisPos;
    public GameObject allTextObj;
    public GameObject[] texts ;
    private int childNum;// 子オブジェクトの数
    public float inputInterval;
    public float textPosXDefalt;
    public float textPosXDiff;
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        childNum = allTextObj.transform.childCount - 1;
        texts = new GameObject[childNum+1];
        for(int i=0; i < childNum+1; i++)
        {
            texts[i] = allTextObj.transform.GetChild(i).gameObject;
        }        
        thisPos = rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < 0)
        {
            if(textNum < childNum)
            {
                if(timeCount == 0)
                {
                    textNum += 1;
                    timeCount += Time.deltaTime;
                }
                else if(timeCount < inputInterval)
                {
                    timeCount += Time.deltaTime; 
                }
                else
                {
                    timeCount = 0;
                }
            }
            else
            {
                timeCount = 0;
            }
        }
        else if(Input.GetAxis("Vertical") > 0)
        {
            if(textNum > 0)
            {
                if(timeCount == 0)
                {
                    textNum -= 1;
                    timeCount += Time.deltaTime;
                }
                else if(timeCount < inputInterval)
                {
                    timeCount += Time.deltaTime; 
                }
                else
                {
                    timeCount = 0;
                }
            }
            else
            {
                timeCount = 0;
            }
            
        }
        else
        {
            timeCount = 0;
        }
        for(int i=0; i < childNum+1; i++)
        {
            var textRectTransform = texts[i].GetComponent<RectTransform>();
            if(textNum == i)
            {
                
                textRectTransform.localPosition = new Vector3(textPosXDiff, textRectTransform.localPosition.y, 0);
                rectTransform.localPosition = new Vector3(thisPos.x, textRectTransform.localPosition.y, thisPos.z);
            }
            else
            {
                textRectTransform.localPosition = new Vector3(textPosXDefalt, textRectTransform.localPosition.y, 0);
            }
        }
    }
}
