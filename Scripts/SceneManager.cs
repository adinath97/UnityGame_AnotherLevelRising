using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static bool next_scene, fade_out, begin_game, game_over_sound_played;
    [SerializeField] AudioClip CountDownSound;
    [SerializeField] [Range(0, 1)] float countDownVolume = .1f;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] [Range(0, 1)] float gameOverVolume = .1f;

    private void Start() {
        if(countDownVolume != .1f) {
            countDownVolume = .1f;
        }
        next_scene = false;
        fade_out = false;
        begin_game = false;
        game_over_sound_played = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(RocketMovement.gameOver)
        {
            RocketMovement.gameOver = false;
            RocketMovement.start_game = false;
            PlatformMovement.start_game = false;
            InfiniteCameraMovement.start_game = false;
            next_scene = true;
            StartCoroutine(LoadGameOverRoutine());
        }
    }

    IEnumerator LoadGameOverRoutine()
    {
        if(!game_over_sound_played) {
            game_over_sound_played = true;
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, countDownVolume);
            yield return new WaitForSeconds(2f);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        yield return null;
    }

    IEnumerator LoadStartSceneRoutine()
    {
        AudioSource.PlayClipAtPoint(CountDownSound, Camera.main.transform.position, gameOverVolume);
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    IEnumerator LoadGameSceneRoutine()
    {
        game_over_sound_played = false;
        AudioSource.PlayClipAtPoint(CountDownSound, Camera.main.transform.position, countDownVolume);
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("InfiniteLevel");
    }

    public void Play()
    {
        next_scene = true;
        RocketMovement.gameOver = false;
        StartCoroutine(LoadGameSceneRoutine());
    }

    public void BeginGame() {
        AudioSource.PlayClipAtPoint(CountDownSound, Camera.main.transform.position, countDownVolume);
        GameSceneManager game_scene_manager = FindObjectOfType<GameSceneManager>();
        game_scene_manager.ToggleUI();

        CountdownText counter = FindObjectOfType<CountdownText>();
        counter.CountDown();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadStartMenu()
    {
        StartCoroutine(LoadStartSceneRoutine());
    }
}
