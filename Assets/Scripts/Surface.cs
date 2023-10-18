using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    [SerializeField] private GameObject surfaceElement;
    [SerializeField] private float surfaceHeight;
    [SerializeField] private float elementRadius;
    [SerializeField] private float heightCorrection;
    [SerializeField] private int elementsCount;

    private List<Rigidbody2D> elements;

    void Awake()
    {
        elements = new List<Rigidbody2D>();
        for(int i = 0; i < elementsCount; i++)
        {
            elements.Add(Instantiate(surfaceElement, new Vector3(transform.position.x + i * 2 * elementRadius, transform.position.y, 0f), Quaternion.identity, transform).GetComponent<Rigidbody2D>());
        }
    }


    void Update()
    {
        foreach (Rigidbody2D rb in elements)
        {
            rb.AddForce(-1 * Vector2.up * (rb.position.y - surfaceHeight) * heightCorrection);
        }
    }
}
