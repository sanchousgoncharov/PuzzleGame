using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class pieceScript : MonoBehaviour
{
    Vector3 rightPosition;
    public bool inRightPosition;
    public bool selected;

    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(1f,7f), Random.Range(-4f,4f));
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!selected)
            {
                if (inRightPosition == false)
                {
                    transform.position = rightPosition;
                    inRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
                
            }
            
        }
    }
}
