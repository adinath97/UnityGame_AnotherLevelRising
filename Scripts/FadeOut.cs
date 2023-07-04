using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadeToBlack;
    public Image fadeOutBlack;
    bool fadeToActivated;

    // Start is called before the first frame update
    void Start()
    {
        fadeOutBlack.enabled = true;
        fadeOutBlack.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(FadeOutBlack());
        
        //initially, not visible
        fadeToBlack.canvasRenderer.SetAlpha(0.0f);
        fadeToBlack.enabled = false;
        fadeToActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.next_scene && !fadeToActivated)
        {
            fadeToActivated = true;
            fadeToBlack.enabled = true;
            fadeToBlack.CrossFadeAlpha(1, 2f, false);
        }

        if(fadeOutBlack.enabled) {
            fadeOutBlack.CrossFadeAlpha(0, 2f, false);
        }
    }

    IEnumerator FadeToBlack() {
        yield return new WaitForSeconds(2f);
        fadeToBlack.enabled = false;
        fadeToActivated = false;
    }

    IEnumerator FadeOutBlack() {
        yield return new WaitForSeconds(2f);
        fadeOutBlack.enabled = false;
    }


}
