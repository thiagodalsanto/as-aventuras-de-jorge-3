using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject dinoPrefab; // O prefab do Dino a ser instanciado

    private int numDinos = 0; // O número atual de Dinos na cena

    private void Start()
    {
        SpawnDino();
    }

    private void Update()
    {
        // Verifica se o número de Dinos é igual a zero
        if (numDinos == 0)
        {
            SpawnDino();
        }
    }

    private void SpawnDino()
    {
        // Gera coordenadas aleatórias dentro do terreno
        float randomX = Random.Range(-1000f, 1000f); // Altere os valores -100f e 100f conforme necessário para definir os limites do terreno no eixo X
        float randomZ = Random.Range(-1000f, 1000f); // Altere os valores -100f e 100f conforme necessário para definir os limites do terreno no eixo Z
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // Instancia o novo Dino na posição aleatória
        GameObject newDino = Instantiate(dinoPrefab, randomPosition, Quaternion.identity);
        numDinos++;
    }

    public void DinoDestroyed()
    {
        numDinos--;
    }
}
