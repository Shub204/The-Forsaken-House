using System.Collections;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{
    public GameObject cupObject;
    public GameObject SphereTrig;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        SphereTrig.SetActive(true);
        StartCoroutine(DeActivateSphere());
    }

    IEnumerator DeActivateSphere()
    {
        yield return new WaitForSeconds(0.5f);
        SphereTrig.SetActive(false);
    }
}
