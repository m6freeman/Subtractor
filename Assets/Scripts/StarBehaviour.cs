using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{

	SpriteRenderer thisSpriteRenderer;

	public Sprite StarSprite;
	public GameObject SparksParticals;

	// Use this for initialization
	void Awake()
	{
		GameManager.instance.Star = gameObject;
		thisSpriteRenderer = GetComponent<SpriteRenderer>();
		GameManager.instance.Star.SetActive(false);
	}
	void Start()
	{
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		//SparksParticals.SetActive(true);
		StartCoroutine(RaiseStarPanelTimedTrigger());
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ChangeTheme()
	{
		thisSpriteRenderer.sprite = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().Star;
	}

	IEnumerator RaiseStarPanelTimedTrigger()
	{
		GameManager.starPanelisUp = true;
		yield return new WaitForSeconds(1);
		GameManager.starPanelisUp = false;
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}