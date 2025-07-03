using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public NumberLockDoor lockedDoor;
    public int passwordLength = 4;  // Default password length
    public Text passwordText;
    private string password;  // Stores the randomly generated password

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip unlockSound;
    public AudioClip wrongSound;

    void Start()
    {
        GeneratePassword();  // Generate a new password at the start of the game
        passwordText.text = "";
    }

    public void GeneratePassword()
    {
        password = "";
        for (int i = 0; i < passwordLength; i++)
        {
            password += Random.Range(0, 10).ToString(); // Random number 0-9
        }

        Debug.Log("Generated Password: " + password); // Log for debugging
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if (number == "Enter")
        {
            Enter();
            return;
        }

        if (passwordText.text.Length < passwordLength)
        {
            passwordText.text += number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(correctSound);
                StartCoroutine(PlayUnlockSound());
            }

            lockedDoor.UnlockDoor();
            passwordText.color = Color.green;
        }
        else
        {
            if (audioSource != null)
                audioSource.PlayOneShot(wrongSound);

            passwordText.color = Color.red;
        }

        StartCoroutine(WaitAndClear());
    }

    IEnumerator PlayUnlockSound()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(unlockSound);
    }

    IEnumerator WaitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }
    public string GetGeneratedPassword()
    {
        return password;
    }
}
