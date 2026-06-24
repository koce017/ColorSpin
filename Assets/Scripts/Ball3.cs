using UnityEngine;

public class Ball3 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color redColor;
    [SerializeField] private GameObject shatterEffect;
    
    private string currentColorName;
    private Color currentColorValue;

    private bool collidedOnce;

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
        if (collidedOnce) return;

        Destroy(gameObject);
        collidedOnce = true;

        if (other.CompareTag(currentColorName))
        {
            GameManager.Instance.IncreaseScore();
            SfxManager.Instance.Play("hit");
        }
        else
        {
            InstaniateShatterEffect();
            SpawnManager3.Instance.Disable();
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
