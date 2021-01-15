using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstState : MonoBehaviour
{
    public GameObject nextState;
    public GameObject bossBGMSpeaker;
    public float fallSpeed;
    public float lowerLimitPos;
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var thisPosY = transform.position.y;
        if(thisPosY > lowerLimitPos)
        {
            transform.position -= new Vector3(0, fallSpeed, 0);
            var player = GameObject.Find("Pickles(Clone)");
            if(player != null)
            {
                playerController = player.GetComponent<PlayerController>();
                playerController.operatability = false;
            }
        }
        else
        {
            BossManager bossManager = GameObject.Find("BossInstantiate").GetComponent<BossManager>();
            bossManager.bossBGMSpeaker = Instantiate(bossBGMSpeaker, transform.position, Quaternion.identity);
            playerController.operatability = true;
            Instantiate(nextState, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
