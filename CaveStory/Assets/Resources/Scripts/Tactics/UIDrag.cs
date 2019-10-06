using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField]
    private Vector3 MinDistance;
    [SerializeField]
    private Vector3 MaxDistance;
    [SerializeField]
    private Vector3 offset;
    public GameObject[] Target;
    
    Vector3 StartPos;

    void Start()
    {
        MinDistance += offset;
        MaxDistance += offset;
    }

    void Update()
    {
        FixPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartPos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        for (int i = 0; i < Target.Length; i++)
        {
            Target[i].transform.position -= StartPos - Input.mousePosition;
        }
            StartPos = Input.mousePosition;
    }
  

    void FixPosition()
    {
        for (int i = 0; i < Target.Length; i++)
        {
            if (Target[i].transform.position.x > MinDistance.x)
            {
                Target[i].transform.position = new Vector3(MinDistance.x, Target[i].transform.position.y, 0);
            }
            if (Target[i].transform.position.x < MaxDistance.x)
            {
                Target[i].transform.position = new Vector3(MaxDistance.x, Target[i].transform.position.y, 0);
            }
            if (Target[i].transform.position.y < MinDistance.y)
            {
                Target[i].transform.position = new Vector3(Target[i].transform.position.x, MinDistance.y, 0);
            }
            if (Target[i].transform.position.y > MaxDistance.y)
            {
                Target[i].transform.position = new Vector3(Target[i].transform.position.x, MaxDistance.y, 0);
            }
        }
    }
}
