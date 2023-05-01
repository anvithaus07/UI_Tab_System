using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

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
    public float kSelectedTabWidthExpand = 0.8f;


    private IEnumerator Start()
    {
        for (int i = 0; i < m_tabPages.Count; i++)
        {
            m_tabPages[i].InitializePageData(m_tabPageData[i]);
        }
        for (int i = 0; i < m_tabButtons.Count; i++)
        {
            m_tabButtons[i].Subscribe(this, m_tabPageData[i].PageText);
        }
        yield return new WaitForSeconds(0.1f);
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
        if (mCurrentSelectedTabView == null || mCurrentSelectedTabView != button)
        {

            if (mCurrentSelectedTabView != null)
                mCurrentSelectedTabView.SetDeselectedState();

            mCurrentSelectedTabView = button;

            mCurrentSelectedTabView.SetSelectedState();


            HideTabView(mPageNumber);
            mPageNumber = (int)button.TabType;
            StartCoroutine(MoveTabSelector(button, button.GetComponent<RectTransform>().sizeDelta.x));
            ActivateTabView(mPageNumber);
        }
    }

    IEnumerator MoveTabSelector(TabButton button, float width)
    {
        yield return new WaitForEndOfFrame();

        float newWidth = (width / 100f) * (kSelectedTabWidthExpand * 100f);
        m_tabSelectedBg.sizeDelta = new Vector2(width + newWidth, m_tabSelectedBg.sizeDelta.y);
        Vector2 endPos = new Vector2(button.GetComponent<RectTransform>().anchoredPosition.x, m_tabSelectedBg.anchoredPosition.y);

        m_tabSelectedBg.DOAnchorPos(endPos, 0.3f);
    }
}
