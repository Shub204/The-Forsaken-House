using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource turnOn;
    public AudioSource turnOff;
    private bool isOn = true;

    void Start()
    {
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (GlobalInventory.hasTorch) // Only allow if torch is in inventory
        {
            if (Input.GetButtonDown("torch"))
            {
                isOn = !isOn;
                flashlight.SetActive(isOn);

                if (isOn) turnOn.Play();
                else turnOff.Play();
            }
        }
    }
}
