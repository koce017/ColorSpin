using UnityEngine;
using System.Collections;

public class SpawnManager3 : MonoBehaviour
{
    public static SpawnManager3 Instance { get; private set; }

    [SerializeField] private float delay;
    [SerializeField] private GameObject ballPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            Instantiate(ballPrefab, transform);
            yield return new WaitForSeconds(delay);
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        foreach (var ball in FindObjectsByType<Ball2>(FindObjectsSortMode.None))
        {
            Destroy(ball.gameObject);
        }
    }
}
