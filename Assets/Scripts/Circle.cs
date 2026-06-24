using System.Collections;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [Header("Pulse Effect")]
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float targetScale = 1.25f;

    private bool isAnimating;
    private Vector3 originalScale;

    protected virtual void Start()
    {
        originalScale = transform.localScale;
    }

    public void Bounce()
    {
        if (!isAnimating)
        {
            StartCoroutine(PulseEffect());        
        }
    }

    private IEnumerator PulseEffect()
    {
        isAnimating = true;
        float timer = 0f;

        // 1. GROW
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * targetScale, Mathf.Sin(progress * Mathf.PI * 0.5f));
            yield return null;
        }

        transform.localScale = originalScale * targetScale;
        timer = 0f;

        // 2. SHRINK
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;
            transform.localScale = Vector3.Lerp(originalScale * targetScale, originalScale, Mathf.Sin(progress * Mathf.PI * 0.5f));
            yield return null;
        }

        transform.localScale = originalScale;
        isAnimating = false;
    }
}
