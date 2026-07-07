using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] protected GameObject shatterEffect;
    
    protected Color currentColor;

    protected void InstaniateShatterEffect()
    {
        var effect = Instantiate(shatterEffect, transform.position, Quaternion.identity);
        var ps = effect.GetComponent<ParticleSystem>();

        var main = ps.main;
        main.startColor = currentColor;

        ps.Play();
    }
}
