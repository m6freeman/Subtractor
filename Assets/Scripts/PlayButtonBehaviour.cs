using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonBehaviour : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		ButtonManager.instance.PlayButton = gameObject;
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.Play(); });
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().PlayButton;	
	}
	
	private void OnDisable() 
	{
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}