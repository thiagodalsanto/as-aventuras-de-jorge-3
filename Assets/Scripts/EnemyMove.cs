using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent inimigo;
    private Transform point;
    public bool rotate180Degrees = false;  // Define se a rotação em 180 graus é ativada

    void Start()
    {
        inimigo = GetComponent<NavMeshAgent>();
        point = GameObject.Find("PlayerCapsule").transform;

        // Verifica se o NavMeshAgent foi corretamente colocado no NavMesh
        if (!inimigo.isOnNavMesh)
        {
            Debug.LogError("O NavMeshAgent não está no NavMesh. Verifique a configuração do NavMesh e a posição inicial do inimigo.");
        }
    }

    void Update()
    {
        if (inimigo.isOnNavMesh)
        {
            inimigo.SetDestination(point.position);

            // Faz o inimigo olhar para o ponto de destino mantendo a rotação nos eixos X e Z
            Vector3 direction = point.position - transform.position;
            direction.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotaciona 180 graus no eixo Y se a opção rotate180Degrees for verdadeira
            if (rotate180Degrees)
            {
                targetRotation *= Quaternion.Euler(0f, 180f, 0f);
            }

            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        }
    }
}
