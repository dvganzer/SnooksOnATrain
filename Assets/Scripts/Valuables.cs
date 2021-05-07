using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuables : MonoBehaviour
{
    Vector2 floatY;
    float originalY;
    public float FloatStrength;
    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        floatY = transform.position;
        floatY.y = originalY + (Mathf.Sin(Time.time) * FloatStrength);
        transform.position = floatY;
    }
}
