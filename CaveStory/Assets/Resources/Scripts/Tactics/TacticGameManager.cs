using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TacticGameManager : MonoBehaviour
{
    public Transform TacticTiles;
    public GameObject Tileprefab;

    // Start is called before the first frame update
    void Start()
    {
        TacticTiles.transform.GetChild(10).GetComponentInChildren<Text>().text = "적";
        TacticTiles.transform.GetChild(16).GetComponentInChildren<Text>().text = "적";
        TacticTiles.transform.GetChild(22).GetComponentInChildren<Text>().text = "적";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
