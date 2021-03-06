﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndingDialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
        StartCoroutine(Type());
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (textDisplay.text.Contains("birds"))
        {
            source.Play();
        }
    }


    public void NextSentence()
    {
        
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            source.Stop();
            continueButton.SetActive(false);
        }
    }

}