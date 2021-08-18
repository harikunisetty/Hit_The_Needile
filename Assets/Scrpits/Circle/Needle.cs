using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] bool canNeedMove;
    [SerializeField] bool toucheCircle;
    [SerializeField] float needleSpeed = 10f;

    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.simulated =false;
        canNeedMove = false;
        toucheCircle = false;

    }
    private void FixedUpdate()
    {
        if (canNeedMove)
            rigidbody.velocity = new Vector2(0f, needleSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.UpdateCoins();
        }


        if (other.gameObject.name == "circle")
        {
            if (toucheCircle == false)
            {
                
                rigidbody.simulated = false;
                toucheCircle = true;
                canNeedMove = false;

                transform.SetParent(other.transform);
                other.GetComponent<Circle>().Needles.Add(this.gameObject);

            }
            

            if (other.gameObject.name == "Needle(clone)")
            {
                Debug.Log("touched needle");
            }
        }
    }
    public void FireNeedle()
    {
        canNeedMove = true;
        rigidbody.simulated = true;
    }
}