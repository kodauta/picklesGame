using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplainManager : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    private bool page1Display = true;
    private bool backMenu = false;
    private float timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(page1Display)
            {
                page1Display = false;
                page1.SetActive(false);
                page2.SetActive(true);
            }
            else if(!backMenu)
            {
                var panel = page2.transform.Find("Canvas/FadeOutPanel");
                var script = panel.GetComponent<FadeOutCamera>();
                script.isFadeOut = true;
                script.fadeBack = false;
                backMenu = true;
            }
        }
        if(backMenu)
        {
            timeCount += Time.deltaTime;
            print(timeCount);
            if(timeCount>1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        
        
    }
}
