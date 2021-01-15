using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageAnnounce : MonoBehaviour
{
    public float displaySpan;
    public float fadeOutTime;
    private float timeCount;
    public FadeOutCamera fadeOutCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > displaySpan)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (timeCount > fadeOutTime)
        {
            fadeOutCamera.isFadeOut = true;
        }
    }
}
