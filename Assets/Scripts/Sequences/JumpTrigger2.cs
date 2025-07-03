using System.Collections;
using UnityEngine;

public class JumpTrigger2 : MonoBehaviour
{
    public AudioSource DoorBang;
    public AudioSource JumpMusic;
    public GameObject Zombie;
    public GameObject TheDoor;
    public AudioSource AmbMusic;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        DoorBang.Play();
        Zombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        AmbMusic.Stop();
        JumpMusic.Play();
    }
}
