using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBeans : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0 , 0);
    }
}
