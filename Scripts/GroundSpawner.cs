using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile1, groundTile2, initial_platform;
    Vector3 nextSpawnPoint = new Vector3(0,0,0);
    public static List<GameObject> platforms = new List<GameObject>();
    //public static List<bool> updated_platforms = new list<bool>();
    public static bool move = false, spawn_next_tile = false;
    private static int current_tile_index = 1;
    private static bool instantiate_now = false;
    static bool incremented_score;
    static ScoreManager score_manager;
    private float timer = 0, universal_move_speed = 5.0f;
    public static bool start_game = false;

    void SpawnTile1() {

        nextSpawnPoint = platforms[platforms.Count - 1].transform.position;
        nextSpawnPoint.y += 125.0f;

        GameObject tempTile = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
        //updated_platforms.Add(false);
    }

    void SpawnTile2() {

        nextSpawnPoint = platforms[platforms.Count - 1].transform.position;
        nextSpawnPoint.y += 125.0f;

        GameObject tempTile = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
        //updated_platforms.Add(false);
    }

    void SpawnInitialPlatform() {

        GameObject tempTile = Instantiate(initial_platform, nextSpawnPoint, Quaternion.identity) as GameObject;

        platforms.Add(tempTile);
    }

    public static void SpawnNextTile() {
        instantiate_now = true;
    }

    private void Start() {
        score_manager = FindObjectOfType<ScoreManager>();
        incremented_score = false;
        platforms.Clear();
        SpawnInitialPlatform();
        SpawnTile1();
        SpawnTile2();
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

        if(platforms[platforms.Count - 1].GetComponent<PlatformMovement>().UpdateStatus()) { 
            InfiniteCameraMovement.move = true;
        }

        if(!start_game) { return; }

        timer += Time.deltaTime;

        if(timer >= 5.0f) {
            timer = 0.0f;
            universal_move_speed += .25f;
            InfiniteCameraMovement.moveSpeed = universal_move_speed;
            PlatformMovement.moveSpeed = universal_move_speed;
        }
        
    }

    public static void RemovePlatform() {
        GameObject temp = platforms[0];
        platforms.RemoveAt(0);
        platforms.TrimExcess();
        temp.GetComponent<PlatformMovement>().DestroySelf();
        PlatformRemover.allow_trigger = true;
    }

    public static void MoveGround() {
        for(int i = 0; i < platforms.Count; i++) {
            platforms[i].GetComponent<PlatformMovement>().UpdateMovement();
            if(i == platforms.Count - 1) {
                incremented_score = false;
            }
        }
        if(!incremented_score) {
            incremented_score = true;
            score_manager.GetComponent<ScoreManager>().IncrementScore();
        }
    }
}
