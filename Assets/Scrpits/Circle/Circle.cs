using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float angle;
    [SerializeField] bool canRotate;

    [SerializeField] List<GameObject> needles;
    public List<GameObject> Needles { get => needles; set => needles = value; }

    void Start()
    {
        speed = 50;
        canRotate = true;

        Needles = new List<GameObject>(10);
    }

    void Update()
    {
        if (canRotate == false)
            return;

        angle = transform.rotation.eulerAngles.z;
        angle += speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}