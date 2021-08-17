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

    [SerializeField] GameObject brokenCircle;

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

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (needles.Count == GameManager.Instance.numberOfNeedles)
        {
            GameManager.Instance.GameOver();
            BreakCircle();
        }
    }
    public void BreakCircle()
    {
        Debug.Log("Game Over");

        for (int i = 0; i < needles.Count; i++)
        {
            needles[i].GetComponent<Rigidbody2D>().simulated = true;
            needles[i].transform.parent = null;

            float forcex = Random.Range(-50f, 5f);
            float forcey = Random.Range(50f, 300f);
            needles[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(forcex, forcey));

            needles[i].AddComponent<Death>().lifeTime = 5f;
            Debug.Log(needles[i].transform.name);
        }

        needles.Clear();

        // Create broken circle game object
        Instantiate(brokenCircle, transform.position, Quaternion.identity);

        // remove the circle from the scene
        gameObject.SetActive(false);
    }
   
}