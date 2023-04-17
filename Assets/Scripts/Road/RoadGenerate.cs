using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerate : MonoBehaviour
{
    public GameObject roadTile;

    public List<GameObject> tiles = new();

    Vector2 initialTilePosition = new Vector2(0, 12.5f);

    // Start is called before the first frame update
    void Start()
    {
        Vector2 nextTile = initialTilePosition;

        for (int i = 0; i < 4; i++)
        {
            tiles.Add(Instantiate(roadTile, nextTile, Quaternion.identity));
            nextTile.y -= 6.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tile in tiles)
        {
            if (tile.transform.position.y <= -12.5)
            {
                tiles.Remove(tile);
                Destroy(tile);
                tiles.Add(Instantiate(roadTile, initialTilePosition, Quaternion.identity));
                break;
            }
        }
    }
}
