using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransitionScrollBarBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().LevelTransitionScrollBar;
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}
