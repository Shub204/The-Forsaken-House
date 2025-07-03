using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Opening1 : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource Voice01;
    public AudioSource Voice02;
    public GameObject Tutorial1;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "...where am I?";
        Voice01.Play();
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        TextBox.GetComponent<Text>().text = "I need to get out of here...";
        Voice02.Play();
        yield return new WaitForSeconds(1.7f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent <FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1);
        Tutorial1.SetActive(true);
        Tutorial1.GetComponent<Animator>().Play("TutorialAnim");
        yield return new WaitForSeconds(4);
        Tutorial1.SetActive(false);
    }
}
