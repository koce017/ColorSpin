using UnityEngine;

public class Circle3 : MonoBehaviour
{
    private Vector3 centerPoint;

    private void Start()
    {
        centerPoint = GetChildrenCenter();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.RotateAround(centerPoint, Vector3.forward, -90f);
        }
    }

    private Vector3 GetChildrenCenter()
    {
        var renderers = GetComponentsInChildren<SpriteRenderer>();
        
        if (renderers.Length == 0)
        {
            return transform.position;
        }

        var bounds = renderers[0].bounds;

        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        return bounds.center;
    }
}
