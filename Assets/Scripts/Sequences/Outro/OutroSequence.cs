using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroSequence : MonoBehaviour
{
    public GameObject Creditsrl;
    public GameObject Splashtxt;
    void Start()
    {
        StartCoroutine(EndingScene());
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }
    IEnumerator EndingScene()
    {
        Splashtxt.GetComponent<Animator>().Play("SplashText");
        yield return new WaitForSeconds(1.31f);
        Creditsrl.GetComponent<Animator>().Play("CreditScroll");
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(1);
    }
}
