using UnityEngine;

public class Circle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, 60f);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.spinSfx);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -60f);
            AudioManager.Instance.PlaySfx(AudioManager.Instance.spinSfx);
        }
    }
}
