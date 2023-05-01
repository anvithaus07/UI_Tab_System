using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePage : MonoBehaviour
{
    [SerializeField] private TabView m_tabView;
    
    private Vector2 mStartTouchPos;
    private Vector2 mEndTouchPos;
    private int mPageNumber = 2;

    
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            mStartTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            mEndTouchPos  = Input.GetTouch(0).position;

            if(mEndTouchPos.x<mStartTouchPos.x)
            {
                m_tabView.NextPage();
            }
            if (mEndTouchPos.x > mStartTouchPos.x)
            {
                m_tabView.PreviousPage();
            }
        }
    }
    
}
