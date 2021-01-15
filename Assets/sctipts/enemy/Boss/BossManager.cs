using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject currentBossObject;
    public GameObject bossDead;
    public GameObject bossBGMSpeaker;
    public int bossStageNum;
    public int bossHP;
    public AudioSource audioSource;
    private StatusCounter status;
    private bool isInstantiate = false;
    private bool sceneMove = false;
    public float timeCount; //for random seed
    private float timeCountScene;
    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.Find("Canvas").GetComponent<StatusCounter>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(status.stageNum == bossStageNum)
        {
            if(!isInstantiate)
            {
                currentBossObject = Instantiate(boss, this.transform.position, Quaternion.identity);
                GameObject.Find("BGMSpeaker(Clone)").GetComponent<AudioSource>().Stop();
                isInstantiate = true;
            }
            if(currentBossObject != null)
            {
                var player = GameObject.Find("Pickles(Clone)");
                if(player != null)
                {
                    if(player.transform.position.x < currentBossObject.transform.position.x)
                    {
                        currentBossObject.transform.localScale =  new Vector3(1, 1, 1);
                    }
                    else
                    {
                        currentBossObject.transform.localScale =  new Vector3(-1, 1, 1);
                    }
                }
                if(bossHP == 0)
                {
                    Destroy(bossBGMSpeaker);
                    Instantiate(bossDead, currentBossObject.transform.position, Quaternion.identity);
                    Destroy(currentBossObject.gameObject);
                    sceneMove = true;     
                }
            }
        }
        else
        {
            if(currentBossObject != null)
            {
                Destroy(currentBossObject);
                isInstantiate = false;
            }
        }
        
        if(status.hpCounter == 0)
        {
            Destroy(bossBGMSpeaker);
        }
        if(sceneMove)
        {
            NextScene();
        }

        
        
    }
    void NextScene()
    {
        timeCountScene += Time.deltaTime;
        if(timeCountScene > 3)
        {
            SceneManager.LoadScene("TemporaryEnding");
        }

    }
}
