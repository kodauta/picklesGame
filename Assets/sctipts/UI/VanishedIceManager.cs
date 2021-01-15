using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishedIceManager : MonoBehaviour
{
    public int thisIceGageNum;
    private StatusCounter statusCounter;
    public GameObject IceGage;
    private IceGageManager iceGageManager;
    private GameObject iceGageHolder;
    public float scaleSize;
    // Start is called before the first frame updatSe
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
        if(statusCounter.iceGageCounter >= thisIceGageNum)
        {
            GameObject obj = Instantiate(IceGage, transform.position, Quaternion.identity);
            iceGageManager = obj.GetComponent<IceGageManager>();            
            obj.transform.parent = iceGageHolder.transform;
            obj.transform.localScale = new Vector3(scaleSize,scaleSize,scaleSize);
            iceGageManager.thisIceGageNum = thisIceGageNum;
            Destroy(gameObject);
        }
    }
}
