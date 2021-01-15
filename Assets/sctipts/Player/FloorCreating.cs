using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreating : MonoBehaviour
{
    public float generatingTime;
    public GameObject player;
    private float timeCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > generatingTime)
        {
            Destroy(gameObject);
            Instantiate(player, transform.position, Quaternion.identity);
        }
    }
}
