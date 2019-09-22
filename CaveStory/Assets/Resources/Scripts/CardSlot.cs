using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public bool showCardSlot = false;
    public List<Card> cardslot = new List<Card>(); 
    private CardDataBase db;

    public int slotPos;    //카드 좌표용
    public List<Card> slots = new List<Card>();     //카드슬롯 속성 변수
    
    public GUISkin skin;
    private bool dragCard;
    private Card draggedCard;
    private int prevIndex;

    private bool showTooltip;
    private string tooltip;

    GetTilePos getTilePos;
    void Start()
    {
        getTilePos = GameObject.Find("Tile").GetComponent<GetTilePos>();

        for (int i = 0; i < slotPos; i++)
        {
            slots.Add(new Card());
            // 아이템 슬롯칸에 빈 오브젝트 추가하기
            cardslot.Add(new Card());
        }
        db = GameObject.FindGameObjectWithTag("Card Database").GetComponent<CardDataBase>();

        AddCard(1001);
        // 아이템ID를 호출하도록 한다.
        AddCard(1002);
        AddCard(1003);
        //AddCard(1001);
        // 테스트용 명령어
        //RemoveCard(1001);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showCardSlot = !showCardSlot;
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        if (showCardSlot)
        {
            DrawCardSlot();
            if (showTooltip )
            {
                GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,200), tooltip, skin.GetStyle("tooltip"));
            }
        }
        if (dragCard)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x - 5, Event.current.mousePosition.y - 5, 50, 50), draggedCard.CardIcon);
        }
    }

    void DrawCardSlot()
    {
        int k = 0;
        Event e = Event.current;

        slots[k] = cardslot[k];

        for (int i = 0; i < slotPos; i++)
        {
                Rect slotRect = new Rect(i * 52 + 100, 800, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("slot background"));

                slots[k] = cardslot[k];
            if (slots[k].CardName != null)
            {
                GUI.DrawTexture(slotRect, slots[k].CardIcon);
                if (slotRect.Contains(e.mousePosition))
                {
                    if (e.button == 0 && e.type == EventType.MouseDrag && !dragCard)
                    {
                        dragCard = true;
                        prevIndex = k;
                        draggedCard = slots[k];
                        cardslot[k] = new Card();
                    }
                    if (e.type == EventType.MouseUp && dragCard)
                    {
                        cardslot[prevIndex] = cardslot[k];
                        cardslot[k] = draggedCard;
                        dragCard = false;
                        draggedCard = null;
                    }
                }
                else
                {
                    if (e.type == EventType.MouseUp && dragCard)
                    {
                        cardslot[prevIndex] = draggedCard;
                        dragCard = false;
                        draggedCard = null;

                        if (showTooltip && !dragCard)
                        {
                            tooltip = CreateTooltip(slots[k]);
                            //bringObject(slots[k].CardName);
                            //RemoveCard();
                        }
                    }
                }
                if (e.mousePosition.y < 500)
                {
                        showTooltip = true;
                }
                else showTooltip = false;

            }
            else
            {
                if (slotRect.Contains(e.mousePosition))
                {
                    if (e.type == EventType.MouseUp && dragCard)
                    {
                        cardslot[k] = draggedCard;
                        dragCard = false;
                        draggedCard = null;
                    }
                }
            }

            if (tooltip == "")
            {
                showTooltip = false;
            }

            k++;
        }
    }

    string CreateTooltip(Card card)
    {
        tooltip = "Item name: <color=#a10000><b>" + card.CardName + "</b></color>\n카드 사용: <color=#ffffff>"+"</color>";
        return tooltip;

    }
    void AddCard(int id)
    {
        for (int i = 0; i < cardslot.Count; i++)
        {
            if (cardslot[i].CardName == null)
            {
                for (int j = 0; j < db.cards.Count; j++)
                {
                    if (db.cards[j].CardID == id)
                    {
                        cardslot[i] = db.cards[j];
                        return;
                    }
                }
            }
        }
    }

    bool CardSlotContains(int id)
    {
        for (int i = 0; i < cardslot.Count; i++)
        {
            return (cardslot[i].CardID == id);
        }
        return false;
    }

    void RemoveCard(int id)
    {
        for (int i = 0; i < cardslot.Count; i++)
        {
            if (cardslot[i].CardID == id)
            {
                cardslot[i] = new Card();
                break;
            }
        }
    }

    public void bringObject(string CardName)
    {
        Instantiate(Resources.Load("Prefabs/" + CardName), new Vector3(getTilePos.currentPosition.x, getTilePos.currentPosition.y, 0), Quaternion.identity);
    }
}
