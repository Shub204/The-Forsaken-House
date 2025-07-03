using UnityEngine;

public class DeactivateStalker : MonoBehaviour
{
    private bool isActivated = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = false;
            StalkerAI.isStalking = false;
        }
    }
}
