using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedWarp : MonoBehaviour
{
    public int nextStageNum;
    public GameObject warpPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameObject.Find("Canvas").GetComponent<StatusCounter>().stageNum = nextStageNum;
            col.transform.position = warpPos.transform.position;
        }
    }
}
