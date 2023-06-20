using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float targetScale = 1f;  // Valor final da escala no eixo Z
    public float animationDuration = 1f;  // Duração da animação em segundos

    public void StartScaleAnimation(GameObject obj)
    {
        StartCoroutine(ScaleObject(obj));
    }

    private IEnumerator ScaleObject(GameObject obj)
    {
        Vector3 initialScale = obj.transform.localScale;
        Vector3 targetScaleVector = new Vector3(initialScale.x, initialScale.y, targetScale);

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScaleVector, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a escala seja exatamente igual ao valor final
        obj.transform.localScale = targetScaleVector;
    }
}