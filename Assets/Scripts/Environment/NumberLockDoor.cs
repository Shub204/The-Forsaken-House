using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NumberLockDoor : MonoBehaviour
{
    public float interactionDistance = 2.5f;
    public GameObject Crosshair;
    public GameObject actionText;
    public AudioSource lockedSound;
    public GameObject door;
    public AudioSource openSound;
    public GameObject fadeOut;
    public GameObject loadText;
    public GameObject fadeScreen;

    private bool isUnlocked = false;

    void Start()
    {
        actionText.SetActive(true);  // ✅ Forces UI to be visible for testing
        Crosshair.SetActive(true);
    }

    void Update()
    {
        RaycastHit hit;
        float playerDistance = PlayerCasting.DistanceFromTarget;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                ShowUI();

                if (Input.GetButtonDown("Action"))
                {
                    if (isUnlocked)
                    {
                        OpenDoor();
                    }
                    else
                    {
                        lockedSound.Play();
                    }
                }
                return;
            }
        }

        HideUI();
    }

    void ShowUI()
    {
        actionText.GetComponent<TMPro.TextMeshProUGUI>().text = isUnlocked ? "Open Door" : "Door Locked";
        actionText.SetActive(true);
        Crosshair.SetActive(true);
    }

    void HideUI()
    {
        actionText.SetActive(false);
        Crosshair.SetActive(false);
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
    }

    void OpenDoor()
    {
        openSound.Play();
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        fadeScreen.SetActive(true);
        loadText.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeScreen.SetActive(false);
        loadText.SetActive(false);
        SceneManager.LoadScene(6);
    }
}
