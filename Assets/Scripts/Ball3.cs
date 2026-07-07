using UnityEngine;

public class Ball3 : Ball
{
    [SerializeField] private float speed;

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

        var arcColor = other.GetComponent<SpriteRenderer>().color;  

        if (currentColor.Equals(arcColor))
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
        currentColor = ColorManager.Instance.GetRandomColor();
        spriteRenderer.color = currentColor;
    }
}
