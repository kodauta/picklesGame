using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinder : MonoBehaviour
{
    private BossManager bossManager;
    // Start is called before the first frame update
    void Start()
    {
        bossManager= GameObject.Find("BossInstantiate").GetComponent<BossManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bossManager.currentBossObject = this.gameObject;
    }
}
