using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using TMPro;

public class SpecialRTLTMPro : MonoBehaviour
{
    public static SpecialRTLTMPro instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

    }
    protected readonly FastStringBuilder finalText = new FastStringBuilder(RTLSupport.DefaultBufferSize);
    public string SpecialUpdateText(string input, TextMeshProUGUI textMeshPro)
    {
        if (input == null)
        {
            input = "";
            return input;
        }

        if (TextUtils.IsRTLInput(input) == false)
        {
            textMeshPro.isRightToLeftText = false;
            return input;
        }
        else
        {
            textMeshPro.isRightToLeftText = true;
            return GetFixedText(input, textMeshPro);
        }
    }

    public string GetFixedText(string input, TextMeshProUGUI textMeshPro)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        finalText.Clear();
        RTLSupport.FixRTL(input, finalText, false, true, true);
        if (textMeshPro.isRightToLeftText)
        {
            finalText.Reverse();
        }
        return finalText.ToString();
    }
}
