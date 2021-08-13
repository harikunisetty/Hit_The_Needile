using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needile_Control : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
