using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool isEnter = false;
    private bool isStay = false;
    private bool isExit = false;
    private bool warpPossibility = false;
    public int nextStageNum;
    public GameObject warpPos;
    public GameObject warpBefore;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter || isStay)
        {
            warpPossibility = true;
        }
        else//if(isExit)
        {
            warpPossibility = false;
        }
        isEnter = false;
        isExit = false;
        isStay = false;    
        if(Input.GetButtonDown("Fire2"))
        {       
            
            if(warpPossibility)
            {
                player = GameObject.Find("Pickles(Clone)");
                if(player != null)
                {                
                    GameObject obj =Instantiate(warpBefore, transform.position, Quaternion.identity);
                    WarpBefore script = obj.GetComponent<WarpBefore>();
                    script.stageNum = this.nextStageNum;
                    script.warpPos = this.warpPos;
                    Destroy(player.gameObject);
                }
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
