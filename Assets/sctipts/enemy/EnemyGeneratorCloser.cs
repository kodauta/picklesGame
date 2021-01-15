using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorCloser : MonoBehaviour
{
    public GameObject enemy;
    public float generatableDistanceMin;
    public float generatableDistanceMax;
    private GameObject player;
    private Vector3 playerPos;
    private bool isGenerate = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pickles(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Pickles(Clone)");
        }
        else
        {
            int objChildCount = this.transform.childCount;
            playerPos = player.transform.localPosition;
            float distanceGenerator =  Mathf.Abs(Vector3.Distance(playerPos, transform.localPosition));
            if (generatableDistanceMin < distanceGenerator && distanceGenerator < generatableDistanceMax && objChildCount == 0)
            {
                GameObject obj = Instantiate(enemy, transform.localPosition, Quaternion.identity);
                obj.transform.parent = this.transform;
            }

        }
    }
}
