using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticTile : MonoBehaviour
{
    public enum TileState { EMPTY, UNIT, ENEMY }
    public TileState tileState;
    public Vector3 StartPos;
    public GameObject Unit;
}
