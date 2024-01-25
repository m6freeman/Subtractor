using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelAnimation : MonoBehaviour
{
	public Camera cam;
	public GameObject NextLevelText;
	private string[] NextLevelTexts = new string[6];

	public Image FaderImage;

	public bool Resetting;

	// Use this for initialization
	void Start()
	{
		NextLevelTexts[0] = "Well done!";
		NextLevelTexts[1] = "Great!";
		NextLevelTexts[2] = "Good job!";
		NextLevelTexts[3] = "Wonderful!";
		NextLevelTexts[4] = "Awesome!";
		NextLevelTexts[5] = "Perfect!";

		NextLevelText.GetComponent<Text>().text = NextLevelTexts[Random.Range(0, NextLevelTexts.Length - 1)];
		NextLevelText.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (IsRendererInFrustum(gameObject.GetComponent<Renderer>(), cam))
		{
			StartCoroutine(panelDelay());
		}
		if (Resetting) NextLevelText.GetComponent<Text>().text = "Resetting...";
	}

	public static bool IsRendererInFrustum(Renderer Renderable, Camera Cam)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Cam);
		return GeometryUtility.TestPlanesAABB(planes, Renderable.bounds);
	}

	IEnumerator panelDelay()
	{
		if (GameManager.PerfectScore) NextLevelText.GetComponent<Text>().text = NextLevelTexts[NextLevelTexts.Length - 1];
		NextLevelText.SetActive(true);
		yield return new WaitForSeconds(0.75f);
		NextLevelText.SetActive(false);
	}

}