using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenCircle : MonoBehaviour
{
    void Start()
    {
        float forceY = Random.Range(10f, 200f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forceY));
    }
}
