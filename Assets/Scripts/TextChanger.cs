using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public bool isTurkish = true;

    public void ChangeLanguage(TextMeshProUGUI textMesh)
    {
        if (isTurkish)
        {
            textMesh.text = "ورشة عمل TEDAŞ الرقمية";
            isTurkish = false;
        }
        else
        {
            textMesh.text = "TEDAŞ Dijital Atölye";
            isTurkish = true;
        }
    }
}