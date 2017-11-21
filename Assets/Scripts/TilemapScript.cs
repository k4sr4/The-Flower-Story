using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapScript : MonoBehaviour {
    public GameObject temp;

    void Start()
    {
        for (int y = -1; y < Grid.h + 1; ++y)
        {
            for (int x = 0; x < Grid.w; ++x)
            {
                if (GetComponent<Tilemap>().GetTile(new Vector3Int(x, y, 0)) != null)
                {
                    GameObject tile = Instantiate(temp, new Vector3(x, y, 0), Quaternion.identity);
                    Grid.grid[x + 1, y + 1] = tile.transform;
                }
            }
        }
    }

    public void DeleteTile(int x, int y)
    {
        if (GetComponent<Tilemap>().GetTile(new Vector3Int(x, y, 0)) != null)
        {
            GetComponent<Tilemap>().SetTile(new Vector3Int(x, y, 0), null);
        }
    }
}
