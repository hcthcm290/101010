using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : MonoBehaviour
{
    Vector3 beginPosition;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        beginPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            count = 1;
        }
        else if(count == 1)
        {
            transform.position = beginPosition;
            count = 0;
        }
    }
}
