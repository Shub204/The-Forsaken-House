using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequencing : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dateDisplay;
    public GameObject placeDisplay;
    public AudioSource Voice01;
    public AudioSource Voice02;
    public AudioSource Voice03;
    public AudioSource Voice04;
    public AudioSource Voice05;
    public AudioSource thudSound;
    public GameObject allBlack;
    public GameObject loadText;

    void Start()
    {
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin()
    {
        yield return new WaitForSeconds(3);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        dateDisplay.SetActive(true);
        yield return new WaitForSeconds(7);
        placeDisplay.SetActive(false);
        dateDisplay.SetActive(false);
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "The night of October 29th 2008 changed me forever";
        Voice01.Play();
        yield return new WaitForSeconds(4.5f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "I headed out to investigate the haunting sounds in the woods";
        Voice02.Play();
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(10);
        textBox.GetComponent<Text>().text = "I stumbled upon a clearing with a cabin in the distance";
        Voice03.Play();
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(13);
        textBox.GetComponent<Text>().text = "I could hear those sound coming from there.";
        Voice04.Play();
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(15);
        textBox.GetComponent<Text>().text = "Little did I know this is only the beginning";
        Voice05.Play();
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(10);
        allBlack.SetActive(true);
        thudSound.Play();
        yield return new WaitForSeconds(1);
        loadText.SetActive(true);
        SceneManager.LoadScene(3);
    }
}
