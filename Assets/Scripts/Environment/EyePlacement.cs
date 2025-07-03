using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyePlacement : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject eyePieces;
    public GameObject RealWall;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (GlobalInventory.halfEye1 == true && GlobalInventory.halfEye2 == true)
        {
            if (TheDistance <= 2)
            {
                ActionText.GetComponent<TMPro.TextMeshProUGUI>().text = "Place Eye pieces";
                ActionText.SetActive(true);
            }
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 2)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionText.SetActive(false);
                    eyePieces.SetActive(true);
                    RealWall.GetComponent<Animator>().Play("WallRising");
                }
            }
        }
    }
    void OnMouseExit()
    {
        ActionText.SetActive(false);
    }
}
