using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float breakTime;
    public GameObject blockBreak;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ice")
        {
            var iceBullet = col.gameObject.GetComponent<iceBullet>();
            iceBullet.PlayDestroyAnimation();
            Destroy(col.gameObject);
            Instantiate(blockBreak,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
