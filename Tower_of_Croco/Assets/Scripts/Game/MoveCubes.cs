using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;


    void Start()
    {
        target = new Vector3(-2.77f, 5.53f, 3f);
    }



    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 9f);
            }
            else if (transform.position == target && !moved)
            {
                if (CubeJump.count_blocks != 0)
                {
                    target = new Vector3(transform.position.x - 6f, transform.position.y + 2.29f, transform.position.z);
                }
                CubeJump.jump = false;
                moved = true;
            }

            if (CubeJump.jump)
                moved = false;
        }
        
    }
}
