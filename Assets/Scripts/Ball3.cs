using UnityEngine;

public class Ball3 : Ball
{
    [SerializeField] private float speed;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color redColor;

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
    }

    private void FixedUpdate()
    {   
        rigidbody2D.linearVelocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.CompareTag(currentColorName))
        {
            SfxManager.Instance.Play("hit");
            GameManager.Instance.IncreaseScore();
            other.GetComponentInParent<Circle>().Bounce();
        }
        else
        {
            InstaniateShatterEffect();
            GameManager.Instance.EndGame();
            SpawnManager3.Instance.Disable();
            SfxManager.Instance.Play("shatter");
        }
    }

    private void SetRandomColor()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                currentColorName = "Cyan";
                currentColorValue = cyanColor;
                break;
            case 1:
                currentColorName = "Green";
                currentColorValue = greenColor;
                break;
            case 2:
                currentColorName = "Yellow";
                currentColorValue = yellowColor;
                break;
            case 3:
            default:
                currentColorName = "Red";
                currentColorValue = redColor;
                break;
        }

        spriteRenderer.color = currentColorValue;
    }
}
