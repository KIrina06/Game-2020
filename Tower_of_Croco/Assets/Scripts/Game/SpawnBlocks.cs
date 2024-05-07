using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, allCubes;
    public GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 10f;
    private bool onPlace;

    void Start()
    {
        spawn();


    }

    void Update()
    {
        if (blockInst.transform.position != blockPos && !onPlace)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
        else if (blockInst.transform.position == blockPos)
        {
            onPlace = true;
        }
        if (CubeJump.jump && CubeJump.nextBlock)
        {
            spawn();
            onPlace = false;
        }
    }

    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) > 80)
            rand = Random.Range(1.5f, 3.5f);
        else
            rand = Random.Range(1.5f, 2.5f);
        return rand;
    }

    void spawn()
    {
        blockPos = new Vector3(Random.Range(1f, 4f), Random.Range(-2.8f, 1f), 0f);
        blockInst = Instantiate(block, new Vector3(8f, -6f, 0f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(RandScale(), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = allCubes.transform;
    }
}
