using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject Crosshair;
    public GameObject DoorHinge;
    public AudioSource CreakSound;
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
            Crosshair.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                Crosshair.SetActive(false);
                DoorHinge.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                CreakSound.Play();
            }
        }
        if (TheDistance > 2.5)
        {
            ActionText.SetActive(false);
            Crosshair.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        ActionText.SetActive(false);
        Crosshair.SetActive(false);
    }
}
