using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float rigidbodyTimer;

    [SerializeField] private Color redColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color orangeColor;
    
    private string currentColor;

    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetRandomColor();
        rigidbody2D.simulated = false;
        Invoke(nameof(EnableRigidbody), rigidbodyTimer);
    }

    private void EnableRigidbody()
    {
        rigidbody2D.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(currentColor))
        {
            SetRandomColor();
            GameManager.Instance.IncreaseScore();
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSfx);
        }
        else
        {
            gameObject.SetActive(false);
            GameManager.Instance.SetMenuButtonsActive(true);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.loseSfx);
        }
    }

    private void SetRandomColor()
    {
        Color color;
        switch (Random.Range(0, 7))
        {
            case 0:
                color = redColor;
                currentColor = "Red";
                break;
            case 1:
                color = cyanColor;
                currentColor = "Cyan";
                break;
            case 2:
                currentColor = "Green";
                color = greenColor;
                break;
            case 3:
                currentColor = "Purple";
                color = purpleColor;
                break;
            case 4:
                currentColor = "Yellow";
                color = yellowColor;
                break;
            case 5:
            default:
                currentColor = "Orange";
                color = orangeColor;
                break;
        }
        
        spriteRenderer.color = color;
        GameManager.Instance.UpdateScoreColor(color);
    }
}
