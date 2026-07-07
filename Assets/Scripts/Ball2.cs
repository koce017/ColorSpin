using UnityEngine;

public class Ball2 : Ball
{
    [SerializeField] private float speed;

    private bool oneTriggerActivated;

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
        if (oneTriggerActivated) return;

        Destroy(gameObject);
        oneTriggerActivated = true;

        var arcColor = other.GetComponent<SpriteRenderer>().color;  

        if (currentColor.Equals(arcColor))
        {
            SpawnManager2.Instance.Hit();
            SfxManager.Instance.Play("hit");
            GameManager.Instance.IncreaseScore();
            other.GetComponentInParent<Circle>().Bounce();
        }
        else
        {
            InstaniateShatterEffect();
            SpawnManager2.Instance.Disable();
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
