using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private GameObject player;
    public float groundCameraPos;
    public float skyCameraPos;

    public float leftCameraLimitPos;
    public float rightCameraLimitPos;
    private float cameraYposGround;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pickles(Clone)");      
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Pickles(Clone)");
        if(player == null)
        {
            player = GameObject.Find("Damaged(Clone)");
            if(player == null)
            {
                player = GameObject.Find("WarpAfter(Clone)");
            }          
        }
        FollowPlayer(player);
    }
    void FollowPlayer(GameObject obj)
    {
        if (obj == null)
        {
            this.transform.position = this.transform.position;
        }
        else
        {
            if(obj.transform.position.y < groundCameraPos)
            {
                this.transform.position = new Vector3(obj.transform.position.x, groundCameraPos, transform.position.z);

            }
            else if (obj.transform.position.y > skyCameraPos)
            {
                this.transform.position = new Vector3(obj.transform.position.x, skyCameraPos, transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);;
            }

            if(obj.transform.position.x < leftCameraLimitPos)
            {
                this.transform.position = new Vector3(leftCameraLimitPos, transform.position.y, transform.position.z);

            }
            else if (obj.transform.position.x > rightCameraLimitPos)
            {
                this.transform.position = new Vector3(rightCameraLimitPos, transform.position.y, transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(obj.transform.position.x, transform.position.y, transform.position.z);;
            }
        }

    }
}
