using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StalkerAI : MonoBehaviour
{
    private NavMeshAgent stalkerAgent;
    public Transform thePlayer;
    public GameObject stalkerEnemy;
    public GameObject flash;

    public static bool isStalking = false;
    private bool isAttacking = false;

    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;

    public float chaseSpeed = 2f;

    private Animator animator;

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        animator = stalkerEnemy.GetComponent<Animator>();
        stalkerAgent.autoTraverseOffMeshLink = false;
    }

    void Update()
    {
        if (!isStalking)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            return;
        }

        if (!isAttacking)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        stalkerAgent.speed = chaseSpeed;
        stalkerAgent.SetDestination(thePlayer.position);
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }

    private void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            stalkerAgent.ResetPath(); // Stop moving while attacking
            StartCoroutine(InflictDamage());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🔴 Enemy entered Player's Collider → ATTACK!");
            AttackPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🟢 Enemy left Player's Collider → Resume Chasing!");
            isAttacking = false;
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
            stalkerAgent.SetDestination(thePlayer.position);
        }
    }

    IEnumerator InflictDamage()
    {
        while (isAttacking)
        {
            Debug.Log("⚠️ ATTACKING PLAYER... Dealing Damage!");

            int hurtGen = Random.Range(1, 4);

            if (hurtGen == 1) hurtSound1.Play();
            if (hurtGen == 2) hurtSound2.Play();
            if (hurtGen == 3) hurtSound3.Play();

            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
            yield return new WaitForSeconds(0.9f);

            GlobalHealth.currentHealth -= 5;
            yield return new WaitForSeconds(1f);
        }
    }
}
