using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonBehaviour : MonoBehaviour
{
	Transform trans;

	// Use this for initialization
	void Start()
	{
		trans = GetComponent<Transform>();
		ButtonManager.instance.ShopButton = gameObject;
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.Shop(); });
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
	}

	// Update is called once per frame
	void Update()
	{
		//if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) trans.localScale = new Vector3(5, 5, 1);
	}

	void ChangeTheme()
	{
		gameObject.GetComponent<Image>().sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().ShopButton;
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}