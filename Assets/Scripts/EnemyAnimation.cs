using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public bool isDead = false;
    public bool isAttack = false;
    public float teleportDelay = 5f;  // Delay in seconds before teleporting the GameObject

    private NavMeshAgent navMeshAgent;
    private float originalSpeed;
    private Vector3 originalPosition;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalSpeed = navMeshAgent.speed;
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            isDead = true;
            animator.SetBool("IsDead", isDead);
            navMeshAgent.speed = 0f;  // Set NavMeshAgent's speed to zero
            StartCoroutine(TeleportAfterDelay());
        }
        else if (other.CompareTag("Player"))
        {
            isAttack = true;
            animator.SetBool("IsAttack", isAttack);
            Debug.Log("Character is attacking!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = false;
            animator.SetBool("IsAttack", isAttack);
        }
    }

    private IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(teleportDelay);

        // Teleport the GameObject to the original position and restore its speed
        transform.position = originalPosition;
        isDead = false;
        animator.SetBool("IsDead", isDead);
        navMeshAgent.speed = originalSpeed;
    }

    private void Update()
    {
        // Reset NavMeshAgent's speed if isDead becomes false again
        if (!isDead && navMeshAgent.speed == 0f)
        {
            navMeshAgent.speed = originalSpeed;
        }
    }
}
