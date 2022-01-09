using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlocks : MonoBehaviour
{
    public Vector3 direction;
    public int amount;
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("PlaceBlocks")]
    public void place()
    {
        for(int i=1;i<amount;i++)
        {
            Instantiate(gameObject, transform.position - (direction*size*i), Quaternion.Euler(-90,0,0));
        }
    }
}
