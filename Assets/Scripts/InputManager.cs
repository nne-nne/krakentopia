using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject waveImpulse;
    [SerializeField] private GameObject impulsesParent;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 position = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(position);
            GameObject newImpulse = Instantiate(waveImpulse, worldPos, Quaternion.identity, impulsesParent.transform);
            newImpulse.GetComponent<WaveImpulse>().DoImpulse(100f);
        }
    }
}
