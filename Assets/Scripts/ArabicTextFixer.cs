using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;
using UnityEngine.Windows;

public class ArabicTextFixer : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string previousText;

    private TMP_FontAsset latinFont;
    public TMP_FontAsset arabicFont;
    //private TMP_FontAsset temporaryRecordFont;

    public bool isArabic = true;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        latinFont = GetComponent<TextMeshProUGUI>().font;
        arabicFont = Resources.Load<TMP_FontAsset>("NotoKufiArabic-Medium SDF");
        SetArabicText(textMeshPro.text);
    }

    void Update()
    {
        string currentState = textMeshPro.text;
        if (!currentState.Equals(previousText))
        {
            SetArabicText(currentState);
        }
    }

    public void SetArabicText(string arabicText)
    {
        string fixedArabicText = SpecialRTLTMPro.instance.SpecialUpdateText(arabicText, textMeshPro);

        if (textMeshPro.isRightToLeftText)
        {
            isArabic = true;
            ChangeFont(textMeshPro);
        }
        else
        {
            isArabic = false;
            ChangeFont(textMeshPro);
        }

        if (!fixedArabicText.Equals(textMeshPro.text))
        {
            textMeshPro.text = fixedArabicText;
            previousText = textMeshPro.text;
        }
    }

    public void ChangeFont(TextMeshProUGUI textMesh)
    {
        //temporaryRecordFont = textMesh.font;

        if (!isArabic)
        {
            textMesh.font = latinFont;
        }
        else
        {
            textMesh.font = arabicFont;
        }

        Debug.Log("Mecvut font: " + textMesh.font);
    }
}