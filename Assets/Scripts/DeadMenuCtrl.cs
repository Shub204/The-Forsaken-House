using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenuCtrl : MonoBehaviour
{
    public GameObject RTMButton;
    public GameObject FadeOut;
    public GameObject LoadText;
    public AudioSource ButtonClick;
    public void ReturnToMenu()
    {
        StartCoroutine(ReturnMenu());
    }
    IEnumerator ReturnMenu()
    {
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        LoadText.SetActive(true);
        SceneManager.LoadScene("GameScene");
    }
}
