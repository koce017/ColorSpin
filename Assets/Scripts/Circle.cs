using UnityEngine;

public class Circle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, 60f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -60f);
        }
    }
}
