using UnityEngine;
public class AmmoPickUp : MonoBehaviour
{
    public GameObject ammoDisplayBox;
    void OnTriggerEnter()
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.AmmoCount += 7;
        gameObject.SetActive(false);
    }
}
