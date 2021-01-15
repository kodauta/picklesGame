using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakingPortal : MonoBehaviour
{
    public GameObject warpPos;
    public GameObject portal;
    public int nextStageNum;
    private Animator anim;
    private float timeCount;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > anim.GetCurrentAnimatorStateInfo(0).length)
        {
            GameObject obj = Instantiate(portal, transform.position, Quaternion.identity);
            Portal script = obj.GetComponent<Portal>();
            script.warpPos = this.warpPos;
            script.nextStageNum = this.nextStageNum;
            Destroy(gameObject);
        }
    }

}
