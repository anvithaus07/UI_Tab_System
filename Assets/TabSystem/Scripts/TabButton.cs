using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;
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

        selectedState.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.InOutBack);
    }
    public void SetDeselectedState()
    {
        deslectedState.SetActive(true);
        selectedState.SetActive(false);
        selectedState.transform.localScale = Vector3.zero;
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
