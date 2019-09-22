using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData data)
    {
        transform.position = Camera.main.WorldToScreenPoint(data.position);
    }
}


