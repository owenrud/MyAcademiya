using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance { get; private set; }
    private TextMeshProUGUI textMeshPro;
    private Button yesBtn;
    private Button NoBtn;

    private void Awake()
    {
        Instance = this;
        textMeshPro = transform.Find("Message").GetComponent<TextMeshProUGUI>();
        yesBtn = transform.Find("YesBtn").GetComponent<Button>();
        NoBtn = transform.Find("NoBtn").GetComponent<Button>();
    Hide();
    }

    public void ShowQuestion(string questionText,Action yesAction , Action noAction)
    {
        gameObject.SetActive(true);
        textMeshPro.text = questionText;
        yesBtn.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });
        NoBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });
    } 
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

