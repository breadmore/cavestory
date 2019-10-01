using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCtrl : MonoBehaviour
{
    Vector3 oripos;
    public GameObject Units;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitMouseCtrl();    
    }

    void UnitMouseCtrl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oripos = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            Debug.Log(oripos.y - Input.mousePosition.y);
            if (oripos.y - Input.mousePosition.y < -100)
            {
                Debug.Log("Up");
                UnitRotate(-90);
                oripos = Input.mousePosition;
            }
            else if (oripos.y - Input.mousePosition.y > 100)
            {
                Debug.Log("Down");
                UnitRotate(90);
                oripos = Input.mousePosition;
            }
            else if (oripos.x - Input.mousePosition.x > 100)
            {
                Debug.Log("Left");
                UnitRotate(180);
                oripos = Input.mousePosition;
            }
            else if (oripos.x - Input.mousePosition.x < -100)
            {
                Debug.Log("Right");
                UnitRotate(0);
                oripos = Input.mousePosition;
            }
        }
    }

    void UnitRotate(float value)
    {
        for (int i = 0; i < Units.transform.childCount; i++)
        {
            Units.transform.GetChild(i).eulerAngles = new Vector3(0, value, 0);
        }
    }
}
