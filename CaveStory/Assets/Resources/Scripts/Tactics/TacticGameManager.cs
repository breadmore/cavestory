using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TacticGameManager : MonoBehaviour
{
    public Transform TacticTiles;
    public TacticTile[] TileComp;
    public GameObject Tileprefab;
    public GameObject enemy;
    [SerializeField]
    private float MaxMap = 120;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<MaxMap; i++)
        {
            Instantiate(Tileprefab, Vector3.zero, Quaternion.identity, TacticTiles);
        }
        for (int i=TacticTiles.childCount -1; i>=0; i--)
        {
            TileComp[i] = TacticTiles.GetChild(i).GetComponent<TacticTile>();
            TacticTiles.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(-880.0f + (160.0f * (i % 12)), 715.0f - (160.0f * (i / 12)), 0);
            TileComp[i].StartPos = new Vector3(4.15f + (8.3f * (i % 12)), 3, 5.0f + (10.0f * (i / 12)));
        }
        TacticTiles.GetChild(33).GetComponentInChildren<Text>().text = "적";
        TacticTiles.GetChild(57).GetComponentInChildren<Text>().text = "적";
        TacticTiles.GetChild(81).GetComponentInChildren<Text>().text = "적";
        TileComp[33].Unit = enemy.transform.GetChild(0).gameObject;
        TileComp[57].Unit = enemy.transform.GetChild(1).gameObject;
        TileComp[81].Unit = enemy.transform.GetChild(2).gameObject;
        TileComp[33].tileState = TacticTile.TileState.ENEMY;
        TileComp[57].tileState = TacticTile.TileState.ENEMY;
        TileComp[81].tileState = TacticTile.TileState.ENEMY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateUnits()
    {
        for(int i=0; i<TileComp.Length; i++)
        {
            if(TileComp[i].tileState == TacticTile.TileState.UNIT)
            {
                TileComp[i].Unit.transform.position = TileComp[i].StartPos;
            }
            else if(TileComp[i].tileState == TacticTile.TileState.ENEMY)
            {
                TileComp[i].Unit.transform.position = TileComp[i].StartPos;
            }
        }
    }
}
