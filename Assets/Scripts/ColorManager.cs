using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    public SpriteRenderer[] arcs;
    public Color[] colors;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < arcs.Length; ++i)
        {
            arcs[i].color = colors[i];
        }
    }

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }
}
