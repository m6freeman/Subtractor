using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpringThemeButtonBehavior : MonoBehaviour {

	public bool SpringThemeUnlocked 
	{
		get { return PlayerPrefs.GetInt("SpringThemeUnlocked") > 0; } 
		set { PlayerPrefs.SetInt("SpringThemeUnlocked", value ? 1 : 0); }
	}
	public Image LockImage;
	public Sprite[] LockImages;
	public bool Unlocked;
	public int CostToUnlock = 50;

	// Use this for initialization
	void Start () 
	{
		SpringThemeUnlocked = true;
		ButtonManager.instance.SpringThemeButton = gameObject;
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.UnlockTheme(); });
		if (SpringThemeUnlocked) gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.ChangeTheme(Themes.Spring); });

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
