using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile1, groundTile2, initial_platform;
    Vector3 nextSpawnPoint = new Vector3(0,0,0);
    public static List<GameObject> platforms = new List<GameObject>();
    public static bool move = false, spawn_next_tile = false;
    private static int current_tile_index = 1;
    private static bool instantiate_now = false;

    
    

    void SpawnTile1() {

        nextSpawnPoint = platforms[platforms.Count - 1].transform.position;
        nextSpawnPoint.y += 125.0f;

        GameObject tempTile = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
    }

    void SpawnTile2() {

        nextSpawnPoint = platforms[platforms.Count - 1].transform.position;
        nextSpawnPoint.y += 125.0f;

        GameObject tempTile = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
    }

    void SpawnInitialPlatform() {

        GameObject tempTile = Instantiate(initial_platform, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
    }

    public static void SpawnNextTile() {
        instantiate_now = true;
    }

    private void Start() {
        platforms.Clear();
        SpawnInitialPlatform();
        SpawnTile1();
        SpawnTile2();
        //SpawnTile1();
        //SpawnTile2();
    }

    private void Update() {
        if(instantiate_now) {
            instantiate_now = false;

            if(current_tile_index == 1) {
                SpawnTile1();
                current_tile_index = 2;
            } else if(current_tile_index == 2) {
                SpawnTile2();
                current_tile_index = 1;
            }
        }

        if(InfiniteCameraMovement.move && spawn_next_tile) {
            spawn_next_tile = false;
            SpawnNextTile();
        }
        
    }

    public static void MoveGround() {
        for(int i = 0; i < platforms.Count; i++) {
            platforms[i].GetComponent<PlatformMovement>().UpdateMovement();
        }
    }
}
