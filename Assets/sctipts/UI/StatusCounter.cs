using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusCounter : MonoBehaviour
{
    public int hpCounter = 5;
    public int lifeCounter = 5;
    public int iceGageCounter = 5;
    public int score;
    public int stageNum = 1;

    public int chargerCounter = 0;
    public GameObject lifeDisplay;
    public GameObject scoreDisplay;
    private float timeCount;
    public float iceRecovertime;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hpCounter >5)
        {
            hpCounter = 5;
        }
        if(iceGageCounter < 5)
        {
            timeCount += Time.deltaTime;
            if(timeCount>iceRecovertime)
            {
                iceGageCounter += 1;
                timeCount = 0;
            }
        }
        else if (iceGageCounter > 5)
        {
            iceGageCounter = 5;
        }
        Text lifeText = lifeDisplay.GetComponent<Text>();
        lifeText.text = "× " + lifeCounter;
        Text scoreText = scoreDisplay.GetComponent<Text>();
        scoreText.text = score.ToString();
        if(lifeCounter == 0)
        {
            SceneManager.LoadScene("GAME OVER FOR PRODUCTION");
        }
    }
}
