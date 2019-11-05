using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CaveStory;

namespace CaveStory
{
	public enum TILE_TYPE
	{
		TERRAIN,
		FURNITURE,
	}
}

public class TileData
{
	public TILE_TYPE TileType { get; set; }
	public Vector3 WorldPosition { get; set; }
	
	/* 아래는 지형, 가구 공통 */
	
	protected bool _canBuiltOnThis = true;
	
	public bool CanBuiltOnThis { get { return _canBuiltOnThis; } }	
	protected bool _canUnitPassThis = true;
	
	public bool CanUnitPassThis { get { return _canUnitPassThis; } }	
}
