using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloorManager : MonoBehaviour
{
    public float iceFloorLifespan;
    public float meltTime;
    public float breakPromotionPlayer;
    public float breakPromotionGround;
    public float diffPlayerY;
    public float diffPlayerX;
    public AudioClip iceBreak;
    public GameObject damaged;
    public GroundCheck ground;
    public float timeCount = 0;
    private Animator anim;
    private bool isRide;
    private AudioSource audioSource;
    private bool isPlay = false;
    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.Find("Pickles(Clone)");
        anim.SetFloat("existTime",timeCount);
        if(timeCount > meltTime && !isPlay && Vector3.Distance(cameraObj.transform.position, transform.position) < 30)
        {
            audioSource.PlayOneShot(iceBreak);
            isPlay = true;
        }
        if(ground.IsGround())
        {
            timeCount += Time.deltaTime * breakPromotionGround;
        }
        else
        {
            timeCount += Time.deltaTime;
        }
        if(timeCount > iceFloorLifespan)
        {
            if(player != null)
            {
                float diffy= player.transform.position.y-transform.position.y;
                if(diffy < diffPlayerY && 0 < diffy && Mathf.Abs(player.transform.position.x-transform.position.x)< diffPlayerX) //乗ってると落ちる
                {
                    Instantiate(damaged, player.transform.position, Quaternion.identity);
                    Damaged script = damaged.GetComponent<Damaged>();
                    script.knockBackDirection = new Vector2(0,0);
                    script.isSetInvincible = false;
                    Destroy(player.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
