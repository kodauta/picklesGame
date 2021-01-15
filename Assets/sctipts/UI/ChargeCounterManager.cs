using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCounterManager : MonoBehaviour
{
    public StatusCounter statusCounter;
    public GameObject chargerCountObj;
    public int thisChargerNum;
    private GameObject obj;
    private bool isInstantiate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(statusCounter.chargerCounter >= thisChargerNum && !isInstantiate)
        {
            obj = Instantiate(chargerCountObj, transform.position, Quaternion.Euler(0,0,-45));
            isInstantiate = true;
            obj.transform.parent = this.transform;
        }
        else if(obj != null && statusCounter.chargerCounter < thisChargerNum)
        {
            isInstantiate = false;
            Destroy(obj);
        }
    }
}
