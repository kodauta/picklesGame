using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloorGenerator : MonoBehaviour
{
    public GameObject iceFloor;
    public GameObject iceMaker;
    public int iceConsumption;
    private GameObject player;

    private PlayerController playerController;
    private GameObject iceGenerator;
    private StatusCounter statusCounter;
    private ice ice;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pickles(Clone)");
        playerController = player.GetComponent<PlayerController>();
        iceGenerator = GameObject.Find("IceGenerator");
        ice = iceGenerator.GetComponent<ice>();
        statusCounter = GameObject.Find("Canvas").GetComponent<StatusCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Pickles(Clone)");
        if (Input.GetAxis("Vertical")<0)
        {
            if(Input.GetButtonDown("Fire1") && player != null && !ice.isIcePossession)
            {
                if(statusCounter.iceGageCounter > 0)
                {
                    
                    statusCounter.iceGageCounter -= iceConsumption;
                    iceFloorGenerator();
                    Instantiate(iceMaker, player.transform.position, Quaternion.identity);
                    Destroy(player.gameObject);
                }
            }
        }
    }

    void iceFloorGenerator()
    {
        GameObject Obj = Instantiate(iceFloor, this.transform.position, Quaternion.identity);
    }
}
