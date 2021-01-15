using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreate : MonoBehaviour
{
    public GameObject Floor;
    private Animator animator;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > animator.GetCurrentAnimatorStateInfo(0).length)
        {

            Instantiate(Floor, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
