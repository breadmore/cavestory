using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CaveStory;

public class GridInitialiser : MonoBehaviour
{
    public static GridInitialiser instance;
	public Tilemap Tilemap;

	private Dictionary<Vector3Int, TerrainData> _tiles = new Dictionary<Vector3Int, TerrainData>();

    public Dictionary<Vector3Int, TerrainData> Tiles
    {
        get { return _tiles; }
    }

	private void Awake() 
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		GenerateMap();
	}

	// Use this for initialization
	private void GenerateMap () 
	{
		foreach (Vector3Int pos in Tilemap.cellBounds.allPositionsWithin)
		{
			var localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            int roadGacha = Random.Range(0, 10);
            bool isRoad = (roadGacha > 8)?true:false;
			if (!Tilemap.HasTile(localPlace)) continue;
			var tile = new TerrainData
			{
                WorldPosition = Tilemap.CellToWorld(localPlace),
                TileType = TILE_TYPE.TERRAIN,
                IsRoad = isRoad
			};
			
			Tiles.Add(new Vector3Int(Mathf.FloorToInt(tile.WorldPosition.x), Mathf.FloorToInt(tile.WorldPosition.y), 0), tile);
		}
	}
}