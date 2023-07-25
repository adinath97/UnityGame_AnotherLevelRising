using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemover : MonoBehaviour
{
    public static bool allow_trigger = true;

    private void OnTriggerEnter(Collider other) {
        if(allow_trigger) {
            allow_trigger = false;
            GroundSpawner.RemovePlatform();
        }
    }
}
