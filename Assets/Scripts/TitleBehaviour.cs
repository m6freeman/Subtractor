using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBehaviour : MonoBehaviour
{
	RectTransform rectTrans;

	// Use this for initialization
	void Start()
	{
		rectTrans = GetComponent<RectTransform>();
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().Title;	
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}