using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderImageBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameManager.instance.Fader = gameObject;
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().Fade;
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}
