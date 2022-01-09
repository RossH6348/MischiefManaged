using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintGenerator : MonoBehaviour
{

    public GameObject footprintTemplate;
    Vector3 oldPos;
    bool leftStep = false;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vector = (gameObject.transform.position - oldPos);
        if(vector.magnitude >= 0.5f)
        {
            oldPos = gameObject.transform.position;

            GameObject footprint = Instantiate(footprintTemplate, oldPos + (leftStep ? gameObject.transform.right * 0.1f : gameObject.transform.right * -0.1f), Quaternion.LookRotation(gameObject.transform.forward));

            footprint.SetActive(true);

            leftStep = !leftStep;

        }

    }

}
