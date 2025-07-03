using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int currentHealth = 20;
    public int internalHealth;
    void Update()
    {
        internalHealth = currentHealth;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
    private void Start()
    {
        SaveSystem.DeleteCheckpoint(); // Clear any saved checkpoint at the start

        PlayerData data = SaveSystem.LoadCheckpoint();
        transform.position = new Vector3(data.x, data.y, data.z);

        // Restore saved health
        GlobalHealth.currentHealth = data.health;

        // Restore inventory
        GlobalInventory.halfEye1 = data.halfEye1;
        GlobalInventory.halfEye2 = data.halfEye2;
        GlobalInventory.hasTorch = data.hasTorch;
    }
}
