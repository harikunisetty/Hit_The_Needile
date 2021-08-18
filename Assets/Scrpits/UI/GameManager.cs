using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Needle Variables")]
    public int numberOfNeedles = 5;
    [SerializeField] float posOffest;

    [Header("Needle")]
    [SerializeField] GameObject needleObject;
    [SerializeField] GameObject[] needles;

    [Header("Fire Button")]
    [SerializeField] int needleIndex;
    [SerializeField] Button fireButton;

    public int Coins { get => coins; }
    private int coins;


    void Start()
    {
        posOffest = 3f;

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
    public void UpdateCoins()
    {
        coins++;

        UiManager.Instance.coinsCountUI();
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
        fireButton = GameObject.Find("Fire_Button").GetComponent<Button>();
        fireButton.onClick.AddListener(() => FireTheNeedle());
    }

    void FireTheNeedle()
    {
        needles[needleIndex].GetComponent<Needle>().FireNeedle();
        needleIndex++;

        UiManager.Instance.UpdateNeedleCountUI();

        if (needleIndex == needles.Length)
        {
            fireButton.onClick.RemoveAllListeners();

            needles = new GameObject[0];
            GameOver();
        }
    }

    public void GameOver()
    {
        needles = new GameObject[0];
    }
    public void LoadNextScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);

    }
}

