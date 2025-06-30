using UnityEngine;
using System.Collections;

public class MonsterDie : MonoBehaviour
{
    public void StartCrushEffect()
    {
        StartCoroutine(CrushEffect());
    }

    private IEnumerator CrushEffect()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 originalPosition = transform.position;
        float crushDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < crushDuration)
        {
            float scaleY = Mathf.Lerp(1f, 0.1f, elapsedTime / crushDuration);
            transform.localScale = new Vector3(originalScale.x, scaleY, originalScale.z);
            transform.position = new Vector3(originalPosition.x, originalPosition.y - (originalScale.y - scaleY) * 0.5f, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);
        transform.position = new Vector3(originalPosition.x, originalPosition.y - (originalScale.y - 0.1f) * 0.5f, originalPosition.z);

        Destroy(gameObject, 0.1f);
    }
}
