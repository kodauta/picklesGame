using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{
    public GameObject attackContinue;
    public GameObject impact;
    public int diveCount;
    public float diveSpeed;
    public float groundLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y > groundLine)
        {
            transform.position -= new Vector3(0, diveSpeed, 0);
        }
        else
        {
            Instantiate(attackContinue, transform.position, Quaternion.identity);
            attackContinue.GetComponent<AttackMotion>().diveCount = diveCount + 1;
            Destroy(gameObject);         
        }
    }
}
