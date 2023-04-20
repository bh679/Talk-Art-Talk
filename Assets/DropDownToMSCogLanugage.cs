﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CognitiveServicesTTS;
using BrennanHatton.AI;

public class DropDownToMSCogLanugage : MonoBehaviour
{
	
	public MSCogVoiceToText voiceToText;
	public SpeechManager speechManager;
	public ArtPromptManager artPromptManager;
	public TMP_Dropdown dropDown;
	
	public string[] values;
	public VoiceName[] voices; 
	public string textBeforeLang;
	
	void Reset()
	{
		dropDown = this.GetComponent<TMP_Dropdown>();
		voiceToText = GameObject.FindFirstObjectByType<MSCogVoiceToText>();
		speechManager = GameObject.FindFirstObjectByType<SpeechManager>();
		artPromptManager = GameObject.FindFirstObjectByType<ArtPromptManager>();
		
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
	    dropDown.onValueChanged.AddListener((int val)=>{ 
	    	Changed(val);
	    });
    }
    
	public void Changed(int val)
	{
		voiceToText.language = values[val];
		speechManager.voiceName = voices[val];
		artPromptManager.languagePrompt = textBeforeLang + dropDown.options[val].text;
	}
}
