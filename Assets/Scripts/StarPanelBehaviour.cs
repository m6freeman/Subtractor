using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPanelBehaviour : MonoBehaviour
{

	Animator anim;
	// Use this for initialization
	void Start()
	{
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		anim = GetComponent<Animator>();
		anim.SetBool("RaiseStarPanel", false);
	}

	// Update is called once per frame
	void Update()
	{
		RaiseOrLowerPanel(GameManager.starPanelisUp);
	}

	public void RaiseOrLowerPanel(bool status)
	{
		anim.SetBool("RaiseStarPanel", status);
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().LevelTransitionScrollBar;	

	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}


}