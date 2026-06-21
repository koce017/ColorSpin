using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    [SerializeField] private Circle circle;

    public void RotateLeft()
    {
        circle.RotateLeft();
    }

    public void RotateRight()
    {
        circle.RotateRight();
    }
}
