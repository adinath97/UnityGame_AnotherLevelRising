using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    
    [SerializeField] List<GameObject> ui_elements;
    
    public void ToggleUI() {
        foreach(GameObject element in ui_elements) {
            element.gameObject.SetActive(false);
        }
    }
}
