using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HPBarSet : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.red;
    [SerializeField] private Color deadColor = Color.gray;

    private Color CurrentColor;

    [Header("Health Gui")]
    [SerializeField] private GameObject HpBar;
    [SerializeField] private GameObject[] hpBlocks;

    private int i = 0;

    private void Start()
    {
       GameObject hpBlocks = HpBar.GetComponent<GameObject>();
    }


    private void Update()
    {
        int hpValue = ((Ink.Runtime.IntValue) DialogueManager
            .GetInstance()
            .GetVariableState("health")).value;

        switch (hpValue)
        {
            case 10:
                foreach (GameObject block in hpBlocks)
                {
                    CurrentColor = hpBlocks[i].GetComponent<Color>();
                    CurrentColor = defaultColor;
                    i++;
                }
                i = 0;
                break;
            case 9:
                foreach (GameObject block in hpBlocks)
                {
                    if (block.tag == "HpBlock10")
                    {
                        CurrentColor = hpBlocks[i].GetComponent<Color>();
                        CurrentColor = deadColor;
                        break;
                    }
                    i++;
                }
                i = 0;
                break;



        }


    }
}