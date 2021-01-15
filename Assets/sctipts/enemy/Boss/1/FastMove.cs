using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMove : MonoBehaviour
{
    public GameObject fastMove;
    public Vector4 moveRange;
    public int moveTimeNum;
    public int moveTimeNumMax;
    public GameObject nextAttackState;
    private AudioSource audioSource;
    private BossManager bossManager;
    private Animator anim;
    private float timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bossManager = GameObject.Find("BossInstantiate").GetComponent<BossManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > anim.GetCurrentAnimatorStateInfo(0).length)
        {
            Random.InitState((int)bossManager.timeCount + (int)System.DateTime.Now.Millisecond);
            var nextPos = new Vector3(Random.Range(moveRange.x, moveRange.y), Random.Range(moveRange.z, moveRange.w), 0);
            var obj =Instantiate(fastMove, nextPos, Quaternion.identity);
            var script = obj.GetComponent<FastMove>();
            script.moveTimeNum = this.moveTimeNum + 1;
            Destroy(gameObject);
        }
        if(moveTimeNum > moveTimeNumMax)
        {
            Instantiate(nextAttackState, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
