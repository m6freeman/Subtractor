using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickerAnimation : MonoBehaviour {

	public Image image;

	[Tooltip("Minimum random flicker intensity")]
	public int minIntensity = 1;
	[Tooltip("Maximum random flicker intensity")]
	public int maxIntensity = 10;
	[Tooltip("How much tho smooth out the randomness; lower values spark, higher values glow")]
	[Range(1, 50)]
	public int smoothing = 5;

	private Queue<float> smoothQueue;
	private float lastSum = 0;

	private System.Random rand;

	
	void Reset()
	{
		smoothQueue.Clear();
		lastSum = 0;
	}

	// Use this for initialization
	void Start () 
	{
		rand = new System.Random();
		smoothQueue = new Queue<float>(smoothing);
		image = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		while (smoothQueue.Count >= smoothing) lastSum -= smoothQueue.Dequeue();
		float newVal = (float)rand.Next(minIntensity, maxIntensity) / 10;
		smoothQueue.Enqueue(newVal);
		lastSum += newVal;
		image.color = new Color(1,1,1, lastSum / (float)smoothQueue.Count);
	}
}
