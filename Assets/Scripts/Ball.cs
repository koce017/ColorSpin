using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private Color magentaColor;
    [SerializeField] private TextMeshProUGUI scoreText;

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
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
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
                scoreText.color = cyanColor;
                spriteRenderer.color = cyanColor;
                break;
            case 1:
                currentColor = "Yellow";
                scoreText.color = yellowColor;
                spriteRenderer.color = yellowColor;
                break;
            case 2:
                currentColor = "Pink";
                scoreText.color = pinkColor;
                spriteRenderer.color = pinkColor;
                break;
            case 3:
                currentColor = "Magenta";
                scoreText.color = magentaColor;
                spriteRenderer.color = magentaColor;
                break;
        }
    }
}
