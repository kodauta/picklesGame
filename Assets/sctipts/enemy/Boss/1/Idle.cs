using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public float fallSpeed;
    public float limitYPos;
    public float restTime;
    public GameObject fastMove;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if(transform.position.y < limitYPos)
        {
            Instantiate(fastMove, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            transform.position -= new Vector3(0, fallSpeed, 0);
        }
    }
}
