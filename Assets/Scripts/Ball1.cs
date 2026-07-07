using UnityEngine;

public class Ball1 : Ball
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float rigidbodyTimer;

    [SerializeField] private Color redColor;
    [SerializeField] private Color blueColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color orangeColor;
    
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
        var arcColor = other.GetComponent<SpriteRenderer>().color;

        if (currentColor.Equals(arcColor))
        {
            SetRandomColor();
            SfxManager.Instance.Play("bounce");
            GameManager.Instance.IncreaseScore();
            other.GetComponentInParent<Circle>().Bounce();
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            Destroy(gameObject);
            InstaniateShatterEffect();
            GameManager.Instance.EndGame();
            SfxManager.Instance.Play("shatter");
        }
    }

    private void SetRandomColor()
    {
        currentColor = ColorManager.Instance.GetRandomColor();
        spriteRenderer.color = currentColor;
        GameManager.Instance.UpdateScoreColor(currentColor);
    }
}
