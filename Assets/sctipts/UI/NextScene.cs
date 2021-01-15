using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float timeToNextScene;
    public float fadeTime;
    public string nextScene;
    private float timeCount;
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("FadePanel");
    }

    // Update is called once per frame
    public void SceneWait()
    {
        timeCount += Time.deltaTime;
        if(timeToNextScene < timeCount)
        {
            SceneManager.LoadScene(nextScene);
        }
        else if(fadeTime < timeCount)
        {
            var script = panel.GetComponent<FadeOutCamera>();
            script.isFadeOut = true;
            script.fadeBack = false;
        }
    }
}
