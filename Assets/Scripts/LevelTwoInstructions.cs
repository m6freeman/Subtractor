using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoInstructions : MonoBehaviour
{

	// Use this for initialization

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GameManager.instance.LevelTwoInstructions = gameObject;
	}
	void Start()
	{
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}