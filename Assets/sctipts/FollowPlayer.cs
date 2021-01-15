using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 distancePlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        distancePlayerCamera = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + distancePlayerCamera;
    }
}
