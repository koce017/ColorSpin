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
    [SerializeField] private GameObject shatterEffect;
    
    private string currentColorName;
    private Color currentColorValue;

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
        if (other.CompareTag(currentColorName))
        {
            SetRandomColor();
            SfxManager.Instance.Play("hit");
            GameManager.Instance.IncreaseScore();
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

    private void InstaniateShatterEffect()
    {
        var effect = Instantiate(shatterEffect, transform.position, Quaternion.identity);
        var ps = effect.GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startColor = currentColorValue;

        ps.Play();
    }

    private void SetRandomColor()
    {
        switch (Random.Range(0, 7))
        {
            case 0:
                currentColorName = "Red";
                currentColorValue = redColor;
                break;
            case 1:
                currentColorName = "Cyan";
                currentColorValue = cyanColor;
                break;
            case 2:
                currentColorName = "Green";
                currentColorValue = greenColor;
                break;
            case 3:
                currentColorName = "Purple";
                currentColorValue = purpleColor;
                break;
            case 4:
                currentColorName = "Yellow";
                currentColorValue = yellowColor;
                break;
            case 5:
            default:
                currentColorName = "Orange";
                currentColorValue = orangeColor;
                break;
        }
        
        spriteRenderer.color = currentColorValue;
        GameManager.Instance.UpdateScoreColor(currentColorValue);
    }
}
