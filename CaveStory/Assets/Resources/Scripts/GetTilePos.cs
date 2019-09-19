using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetTilePos : MonoBehaviour
{

    public Tilemap tilemap;
    public Vector2 currentPosition;
    
    private void Start()
    {
        
    }
    private void Update()
    {
    }
    private void OnMouseOver()
    {
        try
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);
            if (this.tilemap = hit.transform.GetComponent<Tilemap>())
            {
                this.tilemap.RefreshAllTiles();

                int x, y;
                x = this.tilemap.WorldToCell(ray.origin).x;
                y = this.tilemap.WorldToCell(ray.origin).y;

                currentPosition.x = x;
                currentPosition.y = y;
                Vector3Int v3Int = new Vector3Int(x, y, 0);
                //타일 색 바꿀 때 이게 있어야 하더군요
                this.tilemap.SetTileFlags(v3Int, TileFlags.None);
                //타일 색 바꾸기
                this.tilemap.SetColor(v3Int, (Color.red));

            }
        }
        catch (NullReferenceException)
        {

        }
    }
    private void OnMouseExit()
    {
        this.tilemap.RefreshAllTiles();
    }


}
