using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public bool internalDoorKey;
    public static bool halfEye1 = false;
    public static bool halfEye2 = false;
    public static bool hasTorch = false;

    void Update()
    {
        internalDoorKey = firstDoorKey;

    }
}
