using UnityEngine;

public class ActivateStalker : MonoBehaviour
{
    private bool isActivated = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            StalkerAI.isStalking = true;
        }
    }
}
