using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleContainerBehaviour : MonoBehaviour {

	RectTransform rectTrans;

	// Use this for initialization
	void Start () 
	{
		rectTrans = GetComponent<RectTransform>();
		ButtonManager.instance.Title = gameObject;
		//rectTrans.sizeDelta = new Vector2( 550, 220 );
		//if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) rectTrans.sizeDelta = new Vector2( 800, 220 );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
