using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject theKey;
    public GameObject KeyTrigger;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 2.5)
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Pick up Key";
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                theKey.SetActive(false);
                KeyTrigger.SetActive(false);
                GlobalInventory.firstDoorKey = true;
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
}
