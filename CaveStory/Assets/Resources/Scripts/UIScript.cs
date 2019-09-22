using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private CardSlot cardslot;
    private GameObject CardBtn;
    private GameObject InventoryBtn;
    private GameObject TurnEndBtn;
    private GameObject MenuBtn;
    private Text YearTxt;
    private Text PopulationTxt;
    private Text DivinityTxt;
    private Text FoodTxt;

    bool CardShow = false;

    public int Year;
    public int Population;
    public int Divinity;
    public int Food;

    public void Start()
    {
        cardslot = GameObject.Find("MainUI").transform.Find("CardSlot").GetComponent<CardSlot>();

        Year = 1;
        Population = 0;
        Divinity = 0;
        Food = 0;

        CardBtn = GameObject.Find("MainUI").transform.Find("CardSlot").gameObject;
        InventoryBtn = GameObject.Find("MainUI").transform.Find("Inventory").gameObject;
        TurnEndBtn = GameObject.Find("MainUI").transform.Find("TurnEnd").gameObject;
        MenuBtn = GameObject.Find("MainUI").transform.Find("Menu").gameObject;
        YearTxt = GameObject.Find("Year").GetComponent<Text>();
        PopulationTxt = GameObject.Find("Population").GetComponent<Text>();
        DivinityTxt = GameObject.Find("Divinity").GetComponent<Text>();
        FoodTxt = GameObject.Find("Food").GetComponent<Text>();
   
    }
    public void Update()
    {
        YearTxt.text = "동굴 " + Year.ToString() + " 년";
        PopulationTxt.text = "인구 " + Population.ToString();
        DivinityTxt.text = "신성 " + Divinity.ToString();
        FoodTxt.text = "식량 " + Food.ToString();
    }
    public void CardClickCall()
    {
        if (cardslot.showCardSlot == true)
        {
            cardslot.showCardSlot = false;
        }
        else
        {
            cardslot.showCardSlot = true;
        }
    }
    public void InventoryClickCall()
    {

    }
    public void TurnEndClickCall()
    {
        Year++;
    }
    public void MenuClickCall()
    {

    }
    public void YearClickCall()
    {

    }
    public void PopulationClickCall()
    {

    }
    public void DivinityClickCall()
    {

    }
    public void FoodClickCall()
    {

    }
}
