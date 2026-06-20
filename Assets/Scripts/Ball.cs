using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Color redColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color orangeColor;
    [SerializeField] private Button playButton;
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
            AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSfx);
        }
        else
        {
            gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.loseSfx);
        }
    }

    private void SetRandomColor()
    {
        switch (Random.Range(0, 6))
        {
            case 0:
                currentColor = "Red";
                scoreText.color = redColor;
                spriteRenderer.color = redColor;
                break;
            case 1:
                currentColor = "Cyan";
                scoreText.color = cyanColor;
                spriteRenderer.color = cyanColor;
                break;
            case 2:
                currentColor = "Green";
                scoreText.color = greenColor;
                spriteRenderer.color = greenColor;
                break;
            case 3:
                currentColor = "Purple";
                scoreText.color = purpleColor;
                spriteRenderer.color = purpleColor;
                break;
            case 4:
                currentColor = "Yellow";
                scoreText.color = yellowColor;
                spriteRenderer.color = yellowColor;
                break;
            case 5:
                currentColor = "Orange";
                scoreText.color = orangeColor;
                spriteRenderer.color = orangeColor;
                break;
        }
    }
}
