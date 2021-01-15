using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRelation : MonoBehaviour
{
    public GameObject bossDamaged;
    public GameObject effectSpeaker;
    public bool isInstantiate;
    public int damagePoint;
    public float invinsibleTime;
    public int effectNumOfTime;
    public float effectSpan;
    public AudioClip damaged;
    private float timeCount;
    private float timeCountForEffect;
    
    private BossManager bossManager;
    private bool damageEffect;

    // Start is called before the first frame update
    void Start()
    {
        bossManager = GameObject.Find("BossInstantiate").GetComponent<BossManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(damageEffect)
        {
            Blinking();
        }
    }
        void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ice")
        {
            if(timeCount < invinsibleTime)
            {
                damageEffect = true;
                bossManager.bossHP -= damagePoint;        
                var script = col.gameObject.GetComponent<iceBullet>();
                Instantiate(effectSpeaker,transform.position,Quaternion.identity);
                script.PlayDestroyAnimation();
                if(isInstantiate)
                {
                    Instantiate(bossDamaged, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }                        
            }
        }
        else if(col.gameObject.name == "IceFloor(Clone)")
        {
            var script = col.gameObject.GetComponent<IceFloorManager>();
            script.timeCount = script.meltTime;
        }      
    }
    void Blinking()
    {
        int i = 0;
        timeCountForEffect += Time.deltaTime;
        if(timeCountForEffect > effectSpan)
        {
            var sprite = GetComponent<SpriteRenderer>();
            if(sprite.enabled)
            {
                sprite.enabled = false;
            }
            else
            {
                sprite.enabled = true;
            }
            timeCountForEffect += 0;
            i += 1;
        }
        if(i > effectNumOfTime)
        {
            damageEffect = false;
        }
    }
}
