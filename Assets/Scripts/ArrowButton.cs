using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    [SerializeField] private Circle1 circle;

    public void RotateLeft()
    {
        circle.RotateLeft();
    }

    public void RotateRight()
    {
        circle.RotateRight();
    }
}
