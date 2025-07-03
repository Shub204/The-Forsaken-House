using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpPistol : MonoBehaviour
{
    public float TheDistance;
    public GameObject Crosshair;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject GuideArrow;
    public GameObject JumpTrigger;
    public GameObject AmmoHint;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 2.5)
        {
            ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Pick Up The Pistol.";
            ActionText.SetActive(true);
            Crosshair.SetActive(true);
            Debug.Log(gameObject.name);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2.5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
                Crosshair.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                JumpTrigger.SetActive(true);
                AmmoHint.SetActive(true);
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
