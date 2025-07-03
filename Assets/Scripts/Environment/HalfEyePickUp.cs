using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HalfEyePickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject halfEye;
    public GameObject halfFade;
    public GameObject EyeImg;
    public GameObject FoundObjText;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Pick up the HalfEye";
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                
                GlobalInventory.halfEye1 = true;
                StartCoroutine(EyePickedUp());
            }
        }
        if (TheDistance > 5)
        {
            ActionText.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        ActionText.SetActive(false);
    }

    IEnumerator EyePickedUp()
    {
        halfFade.SetActive(true);
        EyeImg.SetActive(true);
        FoundObjText.SetActive(true);
        yield return new WaitForSeconds(2);
        halfFade.SetActive(false);
        EyeImg.SetActive(false);
        FoundObjText.SetActive(false);
        halfEye.SetActive(false);
    }
}
