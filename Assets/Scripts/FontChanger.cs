using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour
{

    public TextMeshProUGUI textMesh;

    public TMP_FontAsset[] tedasFontlari;
    public TMP_FontAsset[] alternatifFontlar;
    public Button[] tedasButtons;
    public Button[] alternatifButtons;

    public TMP_FontAsset font1;
    public TMP_FontAsset font2;
    private bool isFont1 = true;

    void Start()
    {
        for (int i = 0; i < tedasButtons.Length; i++)
        {
            int index = i;
            tedasButtons[i].onClick.AddListener(() => SetFont2(tedasFontlari[index], textMesh));
        }

        for (int i = 0; i < alternatifButtons.Length; i++)
        {
            int index = i;
            alternatifButtons[i].onClick.AddListener(() => SetFont1(alternatifFontlar[index], textMesh));
        }
    }

    public void ChangeFont(TextMeshProUGUI textMesh)
    {
        textMesh.font = font1;

        if (isFont1)
        {
            textMesh.font = font2;
        }
        else
        {
            textMesh.font = font1;
        }

        isFont1 = !isFont1;
        Debug.Log("Current font: " + textMesh.font);
    }

    private void SetFont1(TMP_FontAsset font, TextMeshProUGUI textMesh)
    {
        font1 = font;
        textMesh.font = font1;
        isFont1 = true;
        Debug.Log("Current font: " + textMesh.font);
    }

    private void SetFont2(TMP_FontAsset font, TextMeshProUGUI textMesh)
    {
        font2 = font;
        textMesh.font = font2;
        isFont1 = false;
        Debug.Log("Current font: " + textMesh.font);
    }
}
