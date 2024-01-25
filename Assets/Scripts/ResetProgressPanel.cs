using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetProgressPanel : MonoBehaviour
{

	public Text PenaltyText;

	// Use this for initialization
	void Start()
	{
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		PenaltyText.text = "-" + (int)(GameManager.instance.Stars * GameManager.instance.RestartStarPenalty);
	}





	public void OpenResetProgressPanel()
	{
		gameObject.SetActive(true);
	}

	public void CloseResetProgressPanel()
	{
		gameObject.SetActive(false);
	}

	public void ResetProgress()
	{
		StartCoroutine(GameManager.instance.Reset());
		gameObject.transform.position = new Vector2(10000, 10000);
	}
}