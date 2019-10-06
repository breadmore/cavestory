using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction : MonoBehaviour
{
    public GameObject StageUI;
    public GameObject Game;
    public GameObject TacticUI;
    public TacticGameManager TGM;

    public void ClickCall()
    {
        TacticUI.SetActive(false);
        Game.SetActive(true);
        TGM.CreateUnits();
        TGM.GetComponent<UnitCtrl>().enabled = true;
    }

    public void StageSelectCall()
    {
        StageUI.SetActive(false);
        TacticUI.SetActive(true);
    }
}
