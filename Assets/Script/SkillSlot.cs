using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Skills skill = null;
    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;
    [SerializeField]
    private TMPro.TextMeshProUGUI SkillSlotText;

   
    void Start()
    {
        SkillSlotText.text = skill.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (skill != null)
        {
            descriptionText.text = skill.description;
            nameText.text = skill.name;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }

}
