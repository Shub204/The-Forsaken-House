using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int AmmoCount;
    public GameObject AmmoDisplay;
    public int internalAmmo;

    void Update()
    {
        internalAmmo = AmmoCount;
        AmmoDisplay.GetComponent<Text>().text = "" + AmmoCount;
    }
}
