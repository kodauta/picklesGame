using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBefore : MonoBehaviour
{
    public GameObject warpAfter;
    public GameObject warpPos;
    public float fadeOutTime;
    public int stageNum;
    private Animator animator;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > fadeOutTime)
        {
            var script = GameObject.Find("FadePanel").GetComponent<FadeOutCamera>();
            if(!script.isFadeOut)
            {
                script.isFadeOut = true;
                script.fadeBack = true;
                script.intervalTime = 0.25f;
            }
        }
        if(timeCount > animator.GetCurrentAnimatorStateInfo(0).length)
        {
            StatusCounter script = GameObject.Find("Canvas").GetComponent<StatusCounter>();
            script.stageNum = this.stageNum;
            GameObject obj = Instantiate(warpAfter, warpPos.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
