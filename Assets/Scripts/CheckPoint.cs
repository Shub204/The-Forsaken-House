using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject CheckPointtxt;
    private bool checkpointTriggered = false;

    private void Awake()
    {
        if (CheckPointtxt != null)
        {
            CheckPointtxt.SetActive(false); // Ensure UI is hidden when the scene starts
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !checkpointTriggered)
        {
            SaveSystem.SaveCheckpoint(other.transform.position);

            if (CheckPointtxt != null)
            {
                CheckPointtxt.SetActive(true);
            }

            Debug.Log("Checkpoint Saved!");
            checkpointTriggered = true;
            Invoke("HideCheckpointText", 2f);
        }
    }


    private void HideCheckpointText()
    {
        if (CheckPointtxt != null)
        {
            CheckPointtxt.SetActive(false);
        }
    }
}
