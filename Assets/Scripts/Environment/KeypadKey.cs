using UnityEngine;

public class KeypadKey : MonoBehaviour
{
    public string key;  // Number or function (e.g., "Clear", "Enter")

    void OnMouseDown()  // Detects mouse clicks on this key
    {
        SendKey();
    }

    public void SendKey()
    {
        KeypadController keypad = GetComponentInParent<KeypadController>();
        if (keypad != null)
        {
            keypad.PasswordEntry(key);
        }
    }
}
