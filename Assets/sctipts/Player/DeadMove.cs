using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMove : MonoBehaviour
{
    public float firstSpeed;
    public float gravityAccel;
    public Vector3 respornPos0;
    public Vector3 respornPos1;
    public Vector3 respornPos2;
    public Vector3 respornPos3;
    public Vector3 respornPos4;
    public Vector3 respornPos5;
    public Vector3 respornPos6;
    public Vector3 respornPos7;
    public Vector3 respornPos8;
    
    public float playTime;
    public float fadeOutTime;
    public GameObject respornPlayer;
    public GameObject BGMSpeaker;
    private float timeCount = 0;
    private StatusCounter status;
    private List<Vector3> respornList;
    private FadeOutCamera script;


    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        status = canvas.GetComponent<StatusCounter>();
        respornList = new List<Vector3>(){
            respornPos0, respornPos1, respornPos2, respornPos3, respornPos4,
            respornPos5, respornPos6, respornPos7, respornPos8};
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;
        float posY = transform.position.y + firstSpeed*timeCount - gravityAccel*Mathf.Pow(timeCount,2);
        transform.position = new Vector3 (transform.position.x,posY,0.0f);
        if(timeCount > fadeOutTime)
        {
            script = GameObject.Find("FadePanel").GetComponent<FadeOutCamera>();
            if(!script.isFadeOut)
            {
                script.isFadeOut = true;
                script.intervalTime = 2f;
            }
        }
        if(timeCount > playTime)
        {
            status.hpCounter = 5;
            status.lifeCounter -= 1;
            if(status.lifeCounter != 0)
            {
                Instantiate(respornPlayer, respornList[status.stageNum],Quaternion.identity);
                Destroy(GameObject.Find("BGMSpeaker(Clone)"));
                Instantiate(BGMSpeaker, transform.position, Quaternion.identity);                            
                if(status.stageNum == 6)
                {
                    status.stageNum = 5;
                }
            }
            else
            {
                script.fadeBack = false;
            }     
            Destroy(gameObject);
        }
    }
}
