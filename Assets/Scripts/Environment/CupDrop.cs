using UnityEngine;

public class CupDrop : MonoBehaviour
{
    public AudioSource dropSound;

    void OnCollisionEnter(Collision drop)
    {
        if(drop.relativeVelocity.magnitude > 0.75)
        {
            dropSound.Play();
        }
    }
}
