using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject FadeOut;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 2.5)
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Open Door";
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                FadeOut.SetActive(true);
                StartCoroutine(FadeToExit());
            }
        }
        if (TheDistance > 2.5)
        {
            ActionText.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        ActionText.SetActive(false);
    }

    IEnumerator FadeToExit()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }
}
