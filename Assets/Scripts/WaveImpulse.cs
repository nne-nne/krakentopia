using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveImpulse : MonoBehaviour
{
    [SerializeField] private AnimationCurve impulseCurve;
    [SerializeField] private float forceLifetimeFactor;
    [SerializeField] private float scaleMultiplier;
    public float Force { get; private set; }
    private float t;
    private float lifetime;
    private float animationValue;

    public void DoImpulse(float f)
    {
        Force = f;
        lifetime = f * forceLifetimeFactor;
        t = 0f;
    }

    void Update()
    {
        t += Time.deltaTime;
        if(t >= lifetime)
        {
            Destroy(gameObject);
        }
        animationValue = impulseCurve.Evaluate(t / lifetime);
        Force = animationValue * Force;
        transform.localScale += Vector3.one * animationValue * scaleMultiplier * Time.deltaTime;
    }
}
