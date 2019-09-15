using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObj : MonoBehaviour
{
    public bool isTransparent;

    // Update is called once per frame
    void Update()
    {
        if (isTransparent == true)
        {
            Color col = gameObject.GetComponent<Renderer>().material.color;
            Color fade = new Color(col.r, col.g, col.b, 0.5f);
            gameObject.GetComponent<Renderer>().material.color = fade;
            isTransparent = false;
        }
        else
        {
            Color col = gameObject.GetComponent<Renderer>().material.color;
            Color fade = new Color(col.r, col.g, col.b, 1f);
            gameObject.GetComponent<Renderer>().material.color = fade;
        }
    }
}
