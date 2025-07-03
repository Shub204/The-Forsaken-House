using UnityEngine;
using System.Linq;

public class ClueSpawner : MonoBehaviour
{
    public GameObject cluePrefab; // Assign Clue prefab
    public Transform[] spawnPoints; // Assign multiple wall positions
    public Sprite[] bloodMarkSprites; // Assign exactly 4 blood mark images
    public Sprite[] numberSprites; // Assign 10 number images (0-9)
    public KeypadController keypadController; // Reference to KeypadController

    private void Start()
    {
        SpawnClues();
    }

    void SpawnClues()
    {
        if (keypadController == null)
        {
            Debug.LogError("KeypadController not assigned to ClueSpawner!");
            return;
        }

        string password = keypadController.GetGeneratedPassword(); // Get password from KeypadController

        System.Random rand = new System.Random();

        // Shuffle spawn points and take 4 unique ones
        Transform[] shuffledPoints = spawnPoints.OrderBy(x => rand.Next()).Take(4).ToArray();

        for (int i = 0; i < 4; i++)
        {
            GameObject clue = Instantiate(cluePrefab, shuffledPoints[i].position, shuffledPoints[i].rotation);
            // Assign blood mark in correct order (1st, 2nd, 3rd, 4th clue)
            clue.GetComponent<SpriteRenderer>().sprite = bloodMarkSprites[i];

            // Assign the correct number image based on password order
            int num = int.Parse(password[i].ToString()); // Convert password char to int
            clue.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = numberSprites[num];
        }
    }
}
