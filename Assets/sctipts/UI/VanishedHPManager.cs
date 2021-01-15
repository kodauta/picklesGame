using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishedHPManager : MonoBehaviour
{
    public int thisHpNum;
    private StatusCounter statusCounter;
    public GameObject HPBar;
    private HPManager hPManager;
    private GameObject hPBarHolder;
    public float scaleSize;
    // Start is called before the first frame updatSe
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        statusCounter = canvas.GetComponent<StatusCounter>();
        hPBarHolder = GameObject.Find("HPBarHolder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scaleSize,scaleSize,scaleSize); ///なぜか拡大されて生成されるので
        if(statusCounter.hpCounter >= thisHpNum)
        {
            GameObject obj = Instantiate(HPBar, transform.position, Quaternion.identity);
            hPManager = obj.GetComponent<HPManager>();            
            obj.transform.parent = hPBarHolder.transform;
            obj.transform.localScale = new Vector3(scaleSize,scaleSize,scaleSize);
            hPManager.thisHpNum = thisHpNum;
            Destroy(gameObject);
        }
    }
}
