using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SHalfEyePickUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject halfEye;
    public GameObject halfFade;
    public GameObject EyeImg;
    public GameObject FoundObjText;
    public GameObject fakeWall;
    public GameObject realWall;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Pick up the other HalfEye";
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false); 
                GlobalInventory.halfEye2 = true;
                StartCoroutine(EyePickedUp());
            }
        }
    }
    void OnMouseExit()
    {
        ActionText.SetActive(false);
    }

    IEnumerator EyePickedUp()
    {
        fakeWall.SetActive(false);
        realWall.SetActive(true);
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
