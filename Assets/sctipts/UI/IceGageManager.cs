using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGageManager : MonoBehaviour
{
    public int thisIceGageNum;
    private StatusCounter statusCounter;
    public GameObject vanishedIceGage;
    private VanishedIceManager vanishedIceManager;
    private GameObject iceGageHolder;
    public float scaleSize;
    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
        iceGageHolder = GameObject.Find("IceGageHolder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scaleSize,scaleSize,scaleSize); ///なぜか拡大されて生成されるので
        if(statusCounter.iceGageCounter < thisIceGageNum)
        {
            GameObject obj = Instantiate(vanishedIceGage, transform.position, Quaternion.identity);
            vanishedIceManager = obj.GetComponent<VanishedIceManager>();
            vanishedIceManager.thisIceGageNum = thisIceGageNum;
            obj.transform.parent = iceGageHolder.transform;
            Destroy(gameObject);
        }
    }
}
