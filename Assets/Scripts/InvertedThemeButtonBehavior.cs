using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertedThemeButtonBehavior : MonoBehaviour {

	public bool InvertedThemeUnlocked 
	{
		get { return PlayerPrefs.GetInt("InvertedThemeUnlocked") > 0; } 
		set { PlayerPrefs.SetInt("InvertedThemeUnlocked", value ? 1 : 0); }
	}
	public Image LockImage;
	public Sprite[] LockImages;
	public int CostToUnlock = 10;

	// Use this for initialization
	void Start () 
	{
		InvertedThemeUnlocked = true;
		ButtonManager.instance.InvertedThemeButton = gameObject;
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.UnlockTheme(); });
		if (InvertedThemeUnlocked) gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.ChangeTheme(Themes.Inverted); });
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

}
