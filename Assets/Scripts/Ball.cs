using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] protected GameObject shatterEffect;
    
    protected string currentColorName;
    protected Color currentColorValue;

    protected void InstaniateShatterEffect()
    {
        var effect = Instantiate(shatterEffect, transform.position, Quaternion.identity);
        var ps = effect.GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startColor = currentColorValue;

        ps.Play();
    }
}
