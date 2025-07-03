using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpLight : MonoBehaviour
{
    public GameObject Crosshair;
    public GameObject ActionText;
    public GameObject FakeLight;
    public GameObject RealLight;
    public GameObject FlashLightTrigger;

    void Update()
    {
        if (PlayerCasting.DistanceFromTarget <= 2.5f && PlayerLookingAtObject())
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Pick Up The Torch.";
            ActionText.SetActive(true);
            Crosshair.SetActive(true);

            if (Input.GetButtonDown("Action"))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                Crosshair.SetActive(false);
                FakeLight.SetActive(false);
                RealLight.SetActive(true);
                FlashLightTrigger.SetActive(false);

                GlobalInventory.hasTorch = true;
            }
        }
        else
        {
            ActionText.SetActive(false);
            Crosshair.SetActive(false);
        }
    }

    bool PlayerLookingAtObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.5f))
        {
            return hit.transform.gameObject == this.gameObject;
        }
        return false;
    }
}
