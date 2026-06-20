using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] spawnPoints;

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
        SpawnBall();
    }

    public void SpawnBall()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(ballPrefab, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
