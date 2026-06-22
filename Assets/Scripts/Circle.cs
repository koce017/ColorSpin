using UnityEngine;

public class Circle : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    public void RotateLeft()
    {
        transform.Rotate(0f, 0f, 60f);
    }

    public void RotateRight()
    {
        transform.Rotate(0f, 0f, -60f);
    }
}
