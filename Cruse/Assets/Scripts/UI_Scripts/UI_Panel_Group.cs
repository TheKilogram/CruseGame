using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Panel_Group : MonoBehaviour
{
    public List<GameObject> panels;
    public UI_Tab_Group tabGroup;
    public GameObject currentPanel = null;
    
    void Awake()
    {
        foreach(Transform child in transform)
        {
            panels.Add(child.gameObject);
        }
    }
    public void TogglePanelOn(GameObject selected)
    {
        
            ResetPanels();
            currentPanel = selected;
            selected.SetActive(true);
        
        
        
    }
    public void TogglePanelOff()
    {
        ResetPanels();
        currentPanel = null;

    }
    public void ResetPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
}
