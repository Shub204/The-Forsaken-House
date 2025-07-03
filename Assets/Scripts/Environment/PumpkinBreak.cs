using System.Collections;
using UnityEngine;

public class PumpkinBreak : MonoBehaviour
{
    public GameObject FakePumpkin;
    public GameObject BrokenPumpkin;
    public GameObject Sphere;
    public AudioSource pumpkinBreak;
    public GameObject KeyObject;
    public GameObject KeyTrigger;

    void DamageZombie(int DamageAmount)
    {
        StartCoroutine(BreakPumpkin());
    }

    IEnumerator BreakPumpkin()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        pumpkinBreak.Play();
        KeyObject.SetActive(true);
        KeyTrigger.SetActive(true);
        FakePumpkin.SetActive(false);
        BrokenPumpkin.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Sphere.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        Sphere.SetActive(false);
    }
}
