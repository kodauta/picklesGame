using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMotion : MonoBehaviour
{
    public GameObject dive;
    public GameObject idle;
    public Vector3 defaultDivePos;
    public int diveCountMax;
    public int diveCount;
    public Vector2 yRange;
    public CameraShake cameraShake;
    private GameObject mainCamera;
    private Animator animator;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(cameraShake != null)
        {
            cameraShake.Shake(mainCamera);
        }       
        timeCount += Time.deltaTime;
        if(timeCount > animator.GetCurrentAnimatorStateInfo(0).length)
        {
            var player = GameObject.Find("Pickles(Clone)");
            if(diveCount < diveCountMax)
            {
                if(player != null)
                {
                    var obj = Instantiate(dive, new Vector3(player.transform.position.x, defaultDivePos.y, 0), Quaternion.identity);
                    obj.GetComponent<Dive>().diveCount = diveCount;
                }
                else
                {
                    var obj = Instantiate(dive, defaultDivePos, Quaternion.identity);
                    obj.GetComponent<Dive>().diveCount = diveCount;
                }
            }
            else
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                var nextPos = new Vector3(transform.position.x, Random.Range(yRange.x,yRange.y), 0);
                Instantiate(idle, nextPos, Quaternion.identity);
            }        
            Destroy(gameObject);
        }
    }
}
