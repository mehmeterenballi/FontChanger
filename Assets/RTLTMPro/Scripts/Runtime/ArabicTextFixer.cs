using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;

public class ArabicTextFixer : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string previousState;
    private string originalText;

    private TMP_FontAsset latinFont;
    public TMP_FontAsset arabicFont;
    private TMP_FontAsset temporaryRecordFont;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalText = textMeshPro.text;
        SetArabicText(originalText);
    }

    void Update()
    {
        string currentState = textMeshPro.text;
        if (!currentState.Equals(previousState))
        {
            originalText = currentState;
            SetArabicText(originalText);
        }
    }

    public void SetArabicText(string arabicText)
    {
        if (RTLTextMeshPro.ArabFixer == null)
        {
            RTLTextMeshPro.ArabFixer = new RTLTextMeshPro();
        }
        string fixedArabicText = RTLTextMeshPro.ArabFixer.SpecialUpdateText(arabicText, textMeshPro);
        if (!fixedArabicText.Equals(textMeshPro.text))
        {
            textMeshPro.text = fixedArabicText;
            previousState = textMeshPro.text;
        }
    }
}
