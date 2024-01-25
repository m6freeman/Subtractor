using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBackgroundBehaviour : MonoBehaviour {

	private Image thisImage;

	// Use this for initialization
	void Start () 
	{
		thisImage = GetComponent<Image>();
		if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) thisImage.enabled = false;
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().TitleBackground;	
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}
