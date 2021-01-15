using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitManager : MonoBehaviour
{
    private int stageNum;
    public Vector4 stageLimit;
    public Vector4 stage0Limit;
    public Vector4 stage1Limit;
    public Vector4 stage2Limit;
    public Vector4 stage3Limit;
    public Vector4 stage4Limit;
    public Vector4 stage5Limit;
    public Vector4 stage6Limit;
    public Vector4 stage7Limit;
    public Vector4 stage8Limit;
    private StatusCounter statusCounter;
    private List<Vector4> limitList;
    private camera script;
    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent<camera>();
        statusCounter = GameObject.Find("Canvas").GetComponent<StatusCounter>();
        limitList = new List<Vector4>(){stage0Limit, stage1Limit, stage2Limit, stage3Limit, stage4Limit, stage5Limit, stage6Limit, stage7Limit, stage8Limit};
    }

    // Update is called once per frame
    void Update()
    {
        stageNum = statusCounter.stageNum;
        stageLimit = limitList[stageNum];
        script.leftCameraLimitPos = stageLimit.w;
        script.rightCameraLimitPos = stageLimit.x;
        script.skyCameraPos = stageLimit.y;
        script.groundCameraPos = stageLimit.z;
    }
}
