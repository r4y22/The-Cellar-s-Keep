using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class UIPrompt : MonoBehaviour
{
    public static UIPrompt Instance;
    public TextMeshProUGUI promptText;

    private void Awake()
    {
        Instance = this;
        HidePrompt();
    }

    public void ShowPrompt(string message)
    {
        promptText.text = message;
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }
}