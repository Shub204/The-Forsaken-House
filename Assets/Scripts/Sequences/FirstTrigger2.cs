using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FirstTrigger2 : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;
    public GameObject FirstTrigger;
    public AudioSource Voice03;

    void OnTriggerEnter()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Looks like a weapon on that table.";
        Voice03.Play();
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        TheMarker.SetActive(true);
        FirstTrigger.SetActive(false);
    }
}
