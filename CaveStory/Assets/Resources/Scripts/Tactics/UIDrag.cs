using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 defaultpos;

    void Start()
    {
        defaultpos = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = defaultpos;
    }
    

    void Update()
    {

    }
}


