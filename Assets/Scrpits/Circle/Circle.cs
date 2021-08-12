using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public bool canRotate;
    public float speed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
        speed = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate == false)
            return;
        angle = transform.rotation.eulerAngles.z;
        angle += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }
}
