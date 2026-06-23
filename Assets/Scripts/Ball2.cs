using UnityEngine;

public class Ball2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private GameObject shatterEffect;
    
    private string currentColorName;
    private Color currentColorValue;

    private bool collidedOnce;

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
        if (collidedOnce) return;

        Destroy(gameObject);
        collidedOnce = true;

        if (other.CompareTag(currentColorName))
        {
            SpawnManager.Instance.Hit();
            GameManager.Instance.IncreaseScore();
            SfxManager.Instance.Play("hit");
        }
        else
        {
            InstaniateShatterEffect();
            SpawnManager.Instance.Disable();
            GameManager.Instance.SetMenuButtonsActive(true);
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
                currentColorName = "Purple";
                currentColorValue = purpleColor;
                break;
            case 2:
                currentColorName = "Yellow";
                currentColorValue = yellowColor;
                break;
            case 3:
            default:
                currentColorName = "Pink";
                currentColorValue = pinkColor;
                break;
        }

        spriteRenderer.color = currentColorValue;
        GameManager.Instance.UpdateScoreColor(currentColorValue);
    }
}
