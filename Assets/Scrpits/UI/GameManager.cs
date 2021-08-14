using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Needle Variables")]
    [SerializeField] int numberOfNeedles;
    [SerializeField] float posOffest;

    [Header("Needle")]
    [SerializeField] GameObject needleObject;
    [SerializeField] GameObject[] needles;

    [Header("Fire Button")]
    [SerializeField] int needleIndex;
    [SerializeField] Button fireButton;


   
    void Start()
    {
        posOffest = 5f;
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            Instance = this;


        }

        CreateNeedles();
        GetFireButton();
    }

    void CreateNeedles()
    {
        needles = new GameObject[numberOfNeedles];
        Vector3 offestPos = transform.position;

        for (int i = 0; i < needles.Length; i++)
        {
            offestPos.y -= posOffest;
            needles[i] = Instantiate(needleObject, offestPos, Quaternion.identity, this.gameObject.transform);
        }
    }

    void GetFireButton()
    {
        fireButton = GameObject.Find("Fire_Button").GetComponent< Button > ();
        fireButton.onClick.AddListener(() => FireTheNeedle());
    }

    void FireTheNeedle()
    {
        needles[needleIndex].GetComponent<Needile_Control>().FireNeedle();
        needleIndex++;

        UIManager.Instance.UpdateNeedleCountUI();

        if (needleIndex == needles.Length)
        {
            fireButton.onClick.RemoveAllListeners();

            for (int i = 0; i < needles.Length; i++)
            {
                needles = new GameObject[0];
            }
            GameOver();
        }
    }
}
