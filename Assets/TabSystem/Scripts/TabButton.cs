using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI tabButtonNameTxt;
    [SerializeField] private GameObject selectedState;
    [SerializeField] private GameObject deslectedState;
    [SerializeField] private Tabs m_tabType;

    TabView tabView;
    

    public void Subscribe(TabView tabView,string tabName)
    {
        this.tabView = tabView;
        tabButtonNameTxt.text = tabName;

    }

    public void SetSelectedState()
    {
        selectedState.SetActive(true);
        deslectedState.SetActive(false);
    }
    public void SetDeselectedState()
    {
        deslectedState.SetActive(true);
        selectedState.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabView.OnTabSelected(this);
    }

    public Tabs TabType
    {
        get
        {
            return m_tabType;
        }
    }

}
