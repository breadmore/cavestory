using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public int MapX = 1;
    public int MapY = 1;
    public TileState[, ] Map;
    public Transform Tools;
    public GameObject SettingTile;
    public enum TileState { EMPTY, TREE, STONE};
    public TileState selectObject;
    // Start is called before the first frame update
    void Start()
    {
        Map = new TileState[MapX, MapY];
        for(int i=0; i<MapX; i++)
        {
            for(int j=0; j<MapY; j++)
            {
                Instantiate(SettingTile, new Vector3(i * 1.01f, 0, j * 1.01f), Tools.rotation, Tools);
                Tools.GetChild(i * MapX + j).GetComponent<Tile>().currentX = i;
                Tools.GetChild(i * MapX + j).GetComponent<Tile>().currentY = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSelectObject(int index)
    {
        switch(index)
        {
            case 1:
                if (selectObject == TileState.TREE)
                    selectObject = TileState.EMPTY;
                selectObject = TileState.TREE;
                break;
            case 2:
                if (selectObject == TileState.STONE)
                    selectObject = TileState.EMPTY;
                selectObject = TileState.STONE;
                break;
        }
    }
}
