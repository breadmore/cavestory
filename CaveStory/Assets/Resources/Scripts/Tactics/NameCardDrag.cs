using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NameCardDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject Unit;
    public Sprite SmallNamecard;
    Vector3 defaultpos;
    
    float Distance = 50.0f;

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
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, transform.forward, Distance);
        if (hit2d && hit2d.transform.tag == "TacticTile" && CheckArea())
        {
            if (hit2d.transform.GetComponent<TacticTile>().tileState == TacticTile.TileState.EMPTY )
            {
                hit2d.transform.GetComponent<Image>().sprite = SmallNamecard;
                hit2d.transform.GetChild(0).GetComponent<Text>().text = "";
                hit2d.transform.GetComponent<TacticTile>().tileState = TacticTile.TileState.UNIT;
                hit2d.transform.GetComponent<TacticTile>().Unit = Unit;
                Unit.SetActive(true);
                gameObject.SetActive(false);
            }
            else
                transform.position = defaultpos;
        }
        else
            transform.position = defaultpos;
    }
    bool CheckArea()
    {
        //-415 385  -130 + 400 = 270
        if (transform.position.x > 215 && transform.position.x < 1255 &&
            transform.position.y < 825 && transform.position.y > 155)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


