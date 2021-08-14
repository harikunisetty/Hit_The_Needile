using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    [SerializeField] int speed;
    public float angle;
    public bool canRotate;

    [SerializeField] List<GameObject> needles;
    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        canRotate = true;

        needles = new List<GameObject>(GameManager.Instance.numberOfNeedles);
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate == false)
            return;
        angle = transform.rotation.eulerAngles.z;
        angle += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}