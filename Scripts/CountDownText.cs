using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownText : MonoBehaviour
{
    public GameObject startText;
    public static bool beginGame;
    [SerializeField] AudioClip CountDownSound;
    [SerializeField] [Range(0, 1)] float countDownVolume = .2f;

    private void Start() {
        startText.gameObject.SetActive(false);
        if(countDownVolume != .1f) {
            countDownVolume = .1f;
        }
    }

    public void CountDown() {
        startText.gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(CountDownSound, Camera.main.transform.position, countDownVolume);
        startText.GetComponent<TMP_Text>().text = "3";
        startText.GetComponent<TMP_Text>().color = Color.red;
        StartCoroutine(CountDownAndLoadRoutine());
    }

    IEnumerator CountDownAndLoadRoutine()
    {
        yield return new WaitForSeconds(1f);

        startText.GetComponent<TMP_Text>().text = "2";
        startText.GetComponent<TMP_Text>().color = Color.red;
        yield return new WaitForSeconds(1f);

        startText.GetComponent<TMP_Text>().text = "1";
        startText.GetComponent<TMP_Text>().color = Color.red;
        yield return new WaitForSeconds(1f);

        startText.GetComponent<TMP_Text>().text = "GO!";
        startText.GetComponent<TMP_Text>().color = Color.green;
        yield return new WaitForSeconds(1f);

        startText.gameObject.SetActive(false);
        RocketMovement.start_game = true;
        PlatformMovement.start_game = true;
        InfiniteCameraMovement.start_game = true;
    }
}
