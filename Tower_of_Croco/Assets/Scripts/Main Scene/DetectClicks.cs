using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectClicks : MonoBehaviour
{
    public GameObject[] cube;
    public Text playTxt, study, record;
    public Text gameName;
    public GameObject buttons, m_cube, cubes;
    private bool clicked;
    public Animation block;
    public GameObject spawn_blocks;



    void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true;
            playTxt.gameObject.SetActive(false);
            study.gameObject.SetActive(true);
            record.gameObject.SetActive(true);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -5f;
            buttons.GetComponent<ScrollObjects>().checkPos = -100f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            StartCoroutine(cubetoblock());
            m_cube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            cubes.GetComponent<Animation>().Play();
        }
        else if(clicked && study.gameObject.activeSelf)
            study.gameObject.SetActive(false);
    }
    IEnumerator delCubes()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i < 3)
            {
                yield return new WaitForSeconds(0.4f);
                Destroy(cube[i]);
            }
            if (i >= 3)
            {
                yield return new WaitForSeconds(0.5f);
                Destroy(cube[i]);
            }
        }

        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
    }

    IEnumerator cubetoblock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length+0.5f);
        block.Play();

        m_cube.AddComponent<Rigidbody>();

    }
}
