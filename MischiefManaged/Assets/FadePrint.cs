using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePrint : MonoBehaviour
{
    public SpriteRenderer render;
    public GameObject footPrint;
    float timeLeft = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(footPrint, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if(timeLeft <= 1.5f)
        {
            render.color = new Color(1.0f, 1.0f, 1.0f, timeLeft / 1.5f);
        }
        timeLeft -= Time.deltaTime;

    }
}
