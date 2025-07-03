using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject FadeOut;
    public GameObject LoadText;
    public AudioSource ButtonClick;
    public GameObject RealloadButton;
    public GameObject FakeloadButton;
    public GameObject GameName;
    public int loadInt;

    void Start()
    {
        if (PlayerPrefs.HasKey("CheckpointX")) // Check if a checkpoint exists
        {
            RealloadButton.SetActive(true);
            FakeloadButton.SetActive(false);
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    IEnumerator NewGameStart()
    {
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        LoadText.SetActive(true);
        SceneManager.LoadScene(2);
    }
    public void LoadGame()
    {
        StartCoroutine(LoadGameScene());
    }
    IEnumerator LoadGameScene()
    {
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        LoadText.SetActive(true);
        SceneManager.LoadScene("GameScene");
    }

    public void LoadSite()
    {
        Application.OpenURL("www.linkedin.com/in/shubham-pardhi-03b034296");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
