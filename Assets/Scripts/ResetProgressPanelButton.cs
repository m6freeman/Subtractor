using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgressPanelButton : MonoBehaviour
{

	public GameObject ProgressPanel;
	private float timeToHoldButton = 2.0f;
	private float timeButtonHasBeenHeld;

	private bool holding;

	// Use this for initialization
	void Start()
	{
		holding = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (holding)
		{
			timeButtonHasBeenHeld += Time.deltaTime;
			Debug.Log("Button held for " + timeButtonHasBeenHeld);
		}
		else timeButtonHasBeenHeld = 0;

		if (timeButtonHasBeenHeld >= timeToHoldButton)
		{
			ProgressPanel.GetComponent<ResetProgressPanel>().OpenResetProgressPanel();
			timeButtonHasBeenHeld = 0;
		}
	}

	private void OnMouseDown()
	{
		holding = true;

	}
	private void OnMouseUp()
	{
		holding = false;
	}
}