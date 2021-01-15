using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float blowAwaySpeed;

    public float existTime;
    public float effectCallSpan;
    public GameObject destroyEffect;
    public GameObject explosionEffect;
    public GameObject cloudEffect;
    public GameObject collisionEffect;
    public int effectNumOfTime;
    public float effectRange;
    public AudioClip damagedEnemySound;
    

    private float timeCount = 0;

    public int blowAwayDirection;
    private int effectCount = 0; ///エフェクトn回で消える
    private float effectManageTime = 0;
    private bool isEffectExist = false;
    private bool isPlay = false;
    private List<GameObject> listGameObject;
    private AudioSource audioSource;

    void Start()
    {
        listGameObject = new List<GameObject>(){destroyEffect, cloudEffect, collisionEffect, explosionEffect};
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        transform.position += new Vector3( blowAwayDirection*blowAwaySpeed, 0, 0);
        if(timeCount > existTime)  ///一定時間で消失処理
        {
            blowAwayDirection = 0;
            effectManageTime += Time.deltaTime;
            if(!isEffectExist)
            {
                isEffectExist = true;
                GameObject explosion = Instantiate(listGameObject[3], transform.position, Quaternion.identity); ///最初に爆発エフェクト
                var animator = explosion.GetComponent<Animator>();
                var animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
                Destroy(explosion, animationTime);
            }
            if(effectManageTime > effectCallSpan && effectCount <= effectNumOfTime) ///その他にぎやかし
            {
                if(!isPlay)
                {
                    isPlay = true;
                    audioSource.PlayOneShot(damagedEnemySound);
                }
                effectCount += 1;
                int effectIndex = Random.Range(0, 3); ///エフェクトはランダムなやつを選択したい
                Vector3 randomPos = new Vector3(Random.Range(-effectRange, effectRange), Random.Range(-effectRange, effectRange), 0);
                randomPos += transform.position; ///エフェクトの表示場所もランダムにしたい
                GameObject effect = Instantiate(listGameObject[effectIndex], randomPos, Quaternion.identity);
                var animator = effect.GetComponent<Animator>();
                var animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
                Destroy(effect, animationTime);
                effectManageTime = 0;
            }
            else if(effectCount > effectNumOfTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
