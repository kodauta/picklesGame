using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    private Animator animator;
    private float timeCount = 0;
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
            Destroy(gameObject);
        }
    }
}
