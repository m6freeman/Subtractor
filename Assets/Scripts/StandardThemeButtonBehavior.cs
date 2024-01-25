using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardThemeButtonBehavior : MonoBehaviour {

	public Image LockImage;
	public Sprite[] LockImages;
	public int CostToUnlock;	


	// Use this for initialization
	void Start () 
	{
		ButtonManager.instance.StanadardThemeButton = gameObject;
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {ButtonManager.instance.ChangeTheme(Themes.Standard); });

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
