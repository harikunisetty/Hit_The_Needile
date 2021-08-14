using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needile_Control : MonoBehaviour
{
    [Header("Needle")]
    [SerializeField] bool canNeedeMove;
    [SerializeField] bool touchedcircle;
    [SerializeField] float needleSpeed = 10f;

    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (canNeedeMove)
            rigidbody.velocity = new Vector2(0f, needleSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Circle")
        {
            rigidbody.simulated = false;
            touchedcircle = true;
            canNeedeMove = false;

            transform.SetParent(other.transform);
            other.GetComponent<Circle>().needles.Add(this.gameObject);
        }

        if (other.gameObject.name == "Needle(Clone)")
        {
            Debug.Log("Touched Needle");
        }
    }

    public void FireNeedle()
    {
        canNeedeMove = true;
        rigidbody.simulated = true;
    }
}
