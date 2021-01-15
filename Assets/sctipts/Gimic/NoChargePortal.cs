using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChargePortal : MonoBehaviour
{
    public int chargeNumForAwake;
    public int nextStageNum;
    public GameObject warpPoint;
    public GameObject Awake;
    private bool isEnter = false;
    private bool isStay = false;
    private bool isExit = false;
    private bool awakePossibility = false;
    private GameObject player;
    private GameObject canvas;
    private StatusCounter statusCounter;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter || isStay)
        {
            awakePossibility = true;
        }
        else//if(isExit)
        {
            awakePossibility = false;
        }
        isEnter = false;
        isExit = false;
        isStay = false;    
        if(Input.GetButtonDown("Fire2"))
        {                 
            if(awakePossibility && statusCounter.chargerCounter >= chargeNumForAwake)
            {
                GameObject obj = Instantiate(Awake, transform.position, Quaternion.identity);
                AwakingPortal script = obj.GetComponent<AwakingPortal>();
                script.warpPos = warpPoint;
                script.nextStageNum = this.nextStageNum;
                statusCounter.chargerCounter -= chargeNumForAwake;
                Destroy(gameObject);
            }
            else if(awakePossibility)
            {
                audioSource.Play();
            }
            
        }       
   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isEnter = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isStay = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isExit = true;
        }
    }


}
