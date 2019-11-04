using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private ToolsManager TM;
    public GameObject Tree;
    public GameObject Stone;
    public int currentX;
    public int currentY;
    
    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("ToolsManager").GetComponent<ToolsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        switch (TM.selectObject)
        {
            case ToolsManager.TileState.EMPTY:
                break;
            case ToolsManager.TileState.TREE:
                if (Stone.activeSelf)
                    Stone.SetActive(false);
                else if (Tree.activeSelf)
                    Tree.SetActive(false);
                else
                    Tree.SetActive(true);
                break;
            case ToolsManager.TileState.STONE:
                if (Tree.activeSelf)
                    Tree.SetActive(false);
                else if (Stone.activeSelf)
                    Stone.SetActive(false);
                else
                    Stone.SetActive(true);
                break;
        }        
    }
}
