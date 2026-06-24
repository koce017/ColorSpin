using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public static SpawnManager2 Instance { get; private set; }

    [SerializeField] private float secondBallDelay;
    [SerializeField] private float secondBallChance;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] spawnPoints;

    private int ballCount;

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
        SpawnBalls();
    }

    public void Hit()
    {
        --ballCount;
        if (ballCount == 0)
            SpawnBalls();
    }

    private void SpawnBalls()
    {
        ballCount = 1;
        int[] spawnIdx = new int[] {0, 1, 2, 3}.OrderBy(_ => Random.value).Take(2).ToArray();
        Instantiate(ballPrefab, spawnPoints[spawnIdx[0]].transform.position, Quaternion.identity);

        if (Random.value <= secondBallChance)
        {
            ballCount = 2;
            StartCoroutine(SpawnSecondBall(spawnIdx[1]));
        }
    }

    private IEnumerator SpawnSecondBall(int idx)
    {
        yield return new WaitForSeconds(secondBallDelay);
        Instantiate(ballPrefab, spawnPoints[idx].transform.position, Quaternion.identity);
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
