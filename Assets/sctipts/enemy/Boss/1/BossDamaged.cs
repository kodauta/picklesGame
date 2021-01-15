using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged : MonoBehaviour
{
    public GameObject AttackMotion;
    public int animRepeat;
    private Animator animator;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if(timeCount > animator.GetCurrentAnimatorStateInfo(0).length * animRepeat)
        {
            Instantiate(AttackMotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
