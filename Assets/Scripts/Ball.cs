using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private Color magentaColor;
    [SerializeField] private float jumpForce;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(currentColor))
        {
            SetRandomColor();
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SetRandomColor()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                currentColor = "Cyan";
                spriteRenderer.color = cyanColor;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = yellowColor;
                break;
            case 2:
                currentColor = "Pink";
                spriteRenderer.color = pinkColor;
                break;
            case 3:
                currentColor = "Magenta";
                spriteRenderer.color = magentaColor;
                break;
        }
    }
}
