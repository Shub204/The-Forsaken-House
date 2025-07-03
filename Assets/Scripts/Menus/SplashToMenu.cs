using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TakeToMenu());
    }
    IEnumerator TakeToMenu()
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(1);
    }
}
