using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] Text needleCountTxt;
    [SerializeField] int remainNeedlesCount;
    [SerializeField] Text coinsCountTxt;



    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            Instance = this;
            
        }
        coinsCountTxt.text = "CoinsCount: 00";
    }

    void Start()
    {
        remainNeedlesCount = GameManager.Instance.numberOfNeedles;
        needleCountTxt.text = "Needles: " + remainNeedlesCount;
    }
   
    public void UpdateNeedleCountUI()
    {
        if (remainNeedlesCount > 0)
        {
            remainNeedlesCount--;
            needleCountTxt.text = "Needles: " + remainNeedlesCount;
        }
    }
    public void coinsCountUI()
    {
        coinsCountTxt.text = "CoinsCount: " + GameManager.Instance.Coins.ToString();
    }
}
