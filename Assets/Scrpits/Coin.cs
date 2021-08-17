using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int speed=5;
    /*[SerializeField] float angle;
    [SerializeField] bool canRotate;*/
    [SerializeField] float TimeCounter = 0;
    [SerializeField] float width= 1.94f;
    [SerializeField] float height= 4.13f;


    void Start()
    {
        /*speed = 50;
        canRotate = true;*/



    }


    void Update()
    {
        TimeCounter += Time.deltaTime * speed;
        float x = 1 * width;
            float y = 2 * height;
        float z = 10;

        /*if (canRotate == false)
            return;

        angle = transform.rotation.eulerAngles.z;
        angle += speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 03f, angle));*/
        transform.position = new Vector3(x, y, z);

    }
}
