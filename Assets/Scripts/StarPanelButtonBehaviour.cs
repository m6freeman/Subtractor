using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPanelButtonBehaviour : MonoBehaviour
{

	public GameObject StarPanel;
	public Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = StarPanel.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnMouseDown()
	{
		if (!GameManager.instance.Star.activeSelf)
		{
			GameManager.starPanelisUp = !GameManager.starPanelisUp;
			anim.SetBool("RaiseStarPanel", GameManager.starPanelisUp);
		}

	}
}