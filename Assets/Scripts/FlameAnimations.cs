using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int LightMode;
    public GameObject Flamelight;

    void Update()
    {
        if (LightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    public IEnumerator AnimateLight()
    {
        LightMode = Random.Range(1, 4);
        if (LightMode == 1)
        {
            Flamelight.GetComponent<Animation>().Play("TorchAnim1");
        }
        if (LightMode == 2)
        {
            Flamelight.GetComponent<Animation>().Play("TorchAnim2");
        }
        if (LightMode == 3)
        {
            Flamelight.GetComponent<Animation>().Play("TorchAnim3");
        }
        yield return new WaitForSeconds(0.99f);
        LightMode = 0; 
    }
}
