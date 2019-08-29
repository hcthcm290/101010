using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draghandler : MonoBehaviour
{
    bool selected = false;
    Vector3 lastPosition;

    void Update()
    {
        if (selected)
        {
            Vector3 deltaPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - lastPosition;
            deltaPosition.z = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                Vector3 tempPosition = transform.GetChild(i).position;
                tempPosition += deltaPosition;
                transform.GetChild(i).position = tempPosition;
            }
            lastPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
        if(Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
            lastPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            lastPosition = Camera.main.ScreenToWorldPoint(lastPosition);
        }
    }

}
