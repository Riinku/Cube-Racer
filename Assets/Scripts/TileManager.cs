using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePreFabs;    //crates an array of prefabs that will be spawned

    private Transform playerTransform;
    private float spawnZ = 100.0f;                //Z coordinate at which the tile should be spawned
    private float tileLength = 100.0f;          //how long each tile is 
    private int maxTilesOnScreen = 4;           //max amount of tiles that can be spawned on screen before deleting

    private List<GameObject> spawnedTiles;

    // Start is called before the first frame update
    void Start()
    {
        //once the game starts the tiles are starting to be spawned, the main theme music will begin to play
        spawnedTiles = new List<GameObject>();              //instantiate a list that can keep track of what tiles have been spawned, used so u can delete the older tiles
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     //finds a game object that has the player tag, and gets the transform of that game object
        FindObjectOfType<AudioManager>().Play("GameBGM");

        GameObject initialTile;
        initialTile = Instantiate(tilePreFabs[0]) as GameObject;
        initialTile.transform.SetParent(transform);
        initialTile.transform.position = Vector3.zero;
        spawnedTiles.Add(initialTile);
        

    }

    // Update is called once per frame
    void Update()
    {
        int preFabIndex = UnityEngine.Random.Range(1, 6);           //randomizes the tile number to be spawned fromt the prefab array of tiles
        
        if (playerTransform.position.z > (spawnZ - maxTilesOnScreen*tileLength))
        {
            spawnTile(preFabIndex);
        }

        if (spawnedTiles.Count > maxTilesOnScreen +2)
        {            
            deleteTile();
        }




    }


    private void spawnTile(int preFabIndex)
    {
        GameObject newTile;
        newTile = Instantiate(tilePreFabs[preFabIndex]) as GameObject;
        newTile.transform.SetParent(transform);

        newTile.transform.position = Vector3.forward * (spawnZ);


        spawnZ += tileLength;
        spawnedTiles.Add(newTile);
    }

    private void deleteTile()
    {
        Destroy(spawnedTiles[0]);   //deletes the tile at index 0 from the game
        spawnedTiles.RemoveAt(0);   //removes the tile at index 0 from the list
    }

}
