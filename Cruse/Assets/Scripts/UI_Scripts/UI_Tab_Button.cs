using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class UI_Tab_Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public UI_Tab_Group tab_Group;

    public Image background;

    public UnityEvent onTabClick;
    public UnityEvent onTabUnClick;


    public void OnPointerClick(PointerEventData eventData)
    {
        tab_Group.OnTabClick(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tab_Group.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tab_Group.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        tab_Group = transform.parent.GetComponent<UI_Tab_Group>();
        background = GetComponent<Image>();
        tab_Group.AddTab(this);
    }

    public void Selected()
    {
       if(onTabClick != null)
        {
            onTabClick.Invoke();
        }
    }
    public void Deselected()
    {
        if (onTabUnClick != null)
        {
            onTabUnClick.Invoke();
        }
    }
}
