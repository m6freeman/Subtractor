using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehaviour : MonoBehaviour {
	Animator thisAnimator;
	Transform trans;
	public Camera cam;

	// Use this for initialization
	void Start () 
	{
		thisAnimator = GetComponent<Animator>();
		if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) thisAnimator.enabled = false;
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().Background;

	}
	
	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}
