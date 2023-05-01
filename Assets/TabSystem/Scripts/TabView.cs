using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum Tabs
{
    Area,
    LeaderBoard,
    Home,
    Teams,
    Collection

}
public class TabView : MonoBehaviour
{
    [Header("Tab View")]
    [SerializeField] private List<TabPage> m_tabPages;
    [SerializeField] private List<TabPageData> m_tabPageData;

    [Header("Tab Buttons")]
    [SerializeField] private List<TabButton> m_tabButtons;

    [Header("Tab Selected BG")]
    [SerializeField] private RectTransform m_tabSelectedBg;

    private TabButton mCurrentSelectedTabView;
    int mPageNumber = 2;

    
    private void Start()
    {
        for (int i = 0; i < m_tabPages.Count; i++)
        {
            m_tabPages[i].InitializePageData(m_tabPageData[i]);
        }
        for (int i = 0; i < m_tabButtons.Count; i++)
        {
            m_tabButtons[i].Subscribe(this, m_tabPageData[i].PageText);
        }
        Debug.Log("Start of function " + mPageNumber);
        ShowTabViewFor(m_tabButtons[mPageNumber]);
    }
    #region Tab Page View

    public void NextPage()
    {
        if (mPageNumber < m_tabPages.Count - 1)
        {
            HideTabView(mPageNumber);
            mPageNumber++;
            ShowTabViewFor(m_tabButtons[mPageNumber]);
        }
    }

    public void PreviousPage()
    {
        if (mPageNumber > 0)
        {
            HideTabView(mPageNumber);
            mPageNumber--;
            ShowTabViewFor(m_tabButtons[mPageNumber]);
        }
    }

    void HideTabView(int tabViewId)
    {
        if (tabViewId < m_tabPages.Count)
            m_tabPages[tabViewId].gameObject.SetActive(false);
    }

    void ActivateTabView(int tabViewId)
    {
        if (tabViewId < m_tabPages.Count)
            m_tabPages[tabViewId].gameObject.SetActive(true);
    }

    #endregion

    #region Tab Button

    public void OnTabSelected(TabButton button)
    {
        ShowTabViewFor(button);
    }
    #endregion

    void ShowTabViewFor(TabButton button)
    {
        if (button != null)
        {
            if (mCurrentSelectedTabView != null)
                mCurrentSelectedTabView.SetDeselectedState();

            mCurrentSelectedTabView = button;

            mCurrentSelectedTabView.SetSelectedState();
        }

        HideTabView(mPageNumber);
        mPageNumber = (int)button.TabType;
        Debug.Log("Position is : " + button.transform.position + "  localPosition: " + button.transform.localPosition + "  anchoredPosition : " + button.GetComponent<RectTransform>().anchoredPosition);
        m_tabSelectedBg.anchoredPosition =new Vector2( button.GetComponent<RectTransform>().anchoredPosition.x, m_tabSelectedBg.anchoredPosition.y);
        ActivateTabView(mPageNumber);
    }

    void MoveTabSelector()
    {

    }
}
