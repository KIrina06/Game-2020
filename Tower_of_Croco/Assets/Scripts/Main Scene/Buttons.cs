using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    void OnMouseDown ()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
