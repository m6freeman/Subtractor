using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCountBehaviour : MonoBehaviour
{
	Text thisText;

	// Use this for initialization
	void Start()
	{
		thisText = GetComponent<Text>();
		thisText.text = PlayerPrefs.GetInt("Stars").ToString();
	}

	// Update is called once per frame
	void Update()
	{
		thisText.text = GameManager.instance.Stars.ToString();
	}
}