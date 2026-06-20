using UnityEngine;

public class Ball2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private Color purpleColor;
    
    private string currentColor;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetRandomColor();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(currentColor))
        {
            SpawnManager.Instance.SpawnBall();
            GameManager.Instance.IncreaseScore();
            AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSfx);
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            SpawnManager.Instance.Disable();
            GameManager.Instance.SetPlayButtonActive(true);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.loseSfx);
        }
    }

    private void SetRandomColor()
    {
        Color color;
        switch (Random.Range(0, 4))
        {
            case 0:
                color = cyanColor;
                currentColor = "Cyan";
                break;
            case 1:
                currentColor = "Purple";
                color = purpleColor;
                break;
            case 2:
                currentColor = "Yellow";
                color = yellowColor;
                break;
            case 3:
            default:
                currentColor = "Pink";
                color = pinkColor;
                break;
        }

        spriteRenderer.color = color;
        GameManager.Instance.UpdateScoreColor(color);
    }
}
