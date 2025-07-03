using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int hurtGen;
    public GameObject Flash;

    void Update()
    {
        transform.LookAt(thePlayer.transform);
        if (attackTrigger == false)
        {
            enemySpeed = 0.01f;
            theEnemy.GetComponent<Animation>().Play("Z_Walk");
            transform.position = Vector3.MoveTowards(transform.position,thePlayer.transform.position, enemySpeed);
        }
        if(attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0.00f;
            theEnemy.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine(InFlictDamage());
        }
    }

    private void OnTriggerEnter()
    {
        attackTrigger = true;
    }

    private void OnTriggerExit()
    {
        attackTrigger = false;
    }

    IEnumerator InFlictDamage()
    {
        isAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            HurtSound1.Play();
        }
        if (hurtGen == 2)
        {
            HurtSound2.Play();
        }
        if (hurtGen == 3)
        {
            HurtSound3.Play();
        }
        Flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Flash.SetActive(false);
        yield return new WaitForSeconds(0.9f);
        GlobalHealth.currentHealth -= 5;      
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
