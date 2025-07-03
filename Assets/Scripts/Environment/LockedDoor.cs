using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockedDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject Crosshair;
    public GameObject DoorHinge;
    public AudioSource CreakSound;
    public AudioSource LockedDoorSound;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2.5f)
        {
            if (ActionText != null)
            {
                ActionText.GetComponent<TextMeshProUGUI>().text = "Open Door";
                ActionText.SetActive(true);
            }
            if (Crosshair != null)
            {
                Crosshair.SetActive(true);
            }
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2.5f)
            {
                if (GlobalInventory.firstDoorKey)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionText.SetActive(false);
                    Crosshair.SetActive(false);
                    DoorHinge.GetComponent<Animator>().Play("KeyDoorAnim");
                    CreakSound.Play();
                }
                else
                {
                    LockedDoorSound.Play();
                }
            }
        }
    }

    void OnMouseExit()
    {
        if (ActionText != null)
        {
            ActionText.SetActive(false);
        }
        if (Crosshair != null)
        {
            Crosshair.SetActive(false);
        }
    }
}
