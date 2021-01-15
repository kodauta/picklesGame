using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public int thisHpNum;
    private StatusCounter statusCounter;
    public GameObject vanishedHPBar;
    private VanishedHPManager vanishedHPManager;
    private GameObject hpBarHolder;
    public float scaleSize;
    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
        hpBarHolder = GameObject.Find("HPBarHolder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scaleSize,scaleSize,scaleSize); ///なぜか拡大されて生成されるので
        if(statusCounter.hpCounter < thisHpNum)
        {
            GameObject obj = Instantiate(vanishedHPBar, transform.position, Quaternion.identity);
            vanishedHPManager = obj.GetComponent<VanishedHPManager>();
            vanishedHPManager.thisHpNum = thisHpNum;
            obj.transform.parent = hpBarHolder.transform;
            Destroy(gameObject);
        }
    }
}
