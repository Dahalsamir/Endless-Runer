using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTile = 5;
    public Transform playerPoz;
    public List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< numberOfTile; i++)
        {
            if(i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0, tilePrefabs.Length));            }
        }

    }

    // Update is called once per frame
    void Update()
    { if(playerPoz.transform.position.z -35> zSpawn - (tileLength* numberOfTile))
        {
            spawnTile(Random.Range(0, tilePrefabs.Length));
            DeletTile();
        }
        
    }
    void spawnTile(int tileIndex )
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward*zSpawn,tilePrefabs[tileIndex].transform.rotation);
        activeTiles.Add(go);
        zSpawn +=tileLength;
    }
    void DeletTile()
    {
        Destroy(activeTiles[0]);
       

        activeTiles.RemoveAt(0);
    }
}
