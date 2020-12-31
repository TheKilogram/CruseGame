using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tab_Group : MonoBehaviour
{
    public List<UI_Tab_Button> tabButtons;
    public Sprite tabInactive;
    public Sprite tabHover;
    public Sprite tabActive;

    private UI_Tab_Button selectedTab;

    public void AddTab(UI_Tab_Button tab)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<UI_Tab_Button>();
        }
        tab.background.sprite = tabInactive;
        tabButtons.Add(tab);
        
    }
    
    public void OnTabEnter(UI_Tab_Button tab)
    {
        ResetTabs();
        if (tab != selectedTab)
        {
            tab.background.sprite = tabHover;
        }

    }
    public void OnTabExit(UI_Tab_Button tab)
    {
        ResetTabs();
        
    }
    public void OnTabClick(UI_Tab_Button tab)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselected();
        }

        if(selectedTab != tab)
        {
            selectedTab = tab;
            selectedTab.Selected();
            ResetTabs();
            tab.background.sprite = tabActive;
        }
        else
        {
            selectedTab.Deselected();
            selectedTab = null;
            ResetTabs();
        }
        
    }
    public void ResetTabs()
    {
        foreach(UI_Tab_Button tab in tabButtons)
        {
            if(tab != selectedTab)
            {
                tab.background.sprite = tabInactive;
            }
            
        }
    }
}
