using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarIconBehaviour : MonoBehaviour
{
	Transform trans;
	int originalStars;
	Animator anim;

	// Use this for initialization
	void Start()
	{
		trans = GetComponent<Transform>();
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		anim = GetComponent<Animator>();
		//if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) trans.localScale = new Vector3( 50, 50, 1);
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.Stars != originalStars)
		{
			anim.SetTrigger("StarAdded");
		}

		originalStars = GameManager.instance.Stars;
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().Star;	
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}



}