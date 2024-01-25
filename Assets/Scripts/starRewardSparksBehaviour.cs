using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRewardSparksBehaviour : MonoBehaviour
{
	public GameObject gameObjectToTrack;
	Transform thisTransform;
	Transform theirTransform;


	void Awake()
	{
		GameManager.instance.Star.GetComponent<StarBehaviour>().SparksParticals = gameObject;
		gameObject.SetActive(false);
	}

	void Start()
	{
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		thisTransform = GetComponent<Transform>();
		theirTransform = gameObjectToTrack.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		thisTransform.position = theirTransform.position;
	}

	void ChangeTheme()
	{
		// ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
		// ParticleSystem.MainModule ma = ps.main;
		// ma.startColor = ThemeManager.instance.AppliedTheme.GetComponent<Theme>().StarParticleColor;
	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}