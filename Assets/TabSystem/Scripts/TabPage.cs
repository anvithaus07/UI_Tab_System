using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct TabPageData
{
    public Color PageBgColor;
    public string PageText;
}
public class TabPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_pageNameTxt;
    [SerializeField] private Image m_pageBg;

    public void InitializePageData(TabPageData pageData)
    {
        m_pageNameTxt.text = pageData.PageText;
        m_pageBg.color = pageData.PageBgColor;
    }
}
