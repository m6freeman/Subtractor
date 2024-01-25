using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBackgroundScaleAdjustment : MonoBehaviour
{

    // Purpose: Adjust CanvasScaler MatchWidthOrHeight based on User Screen Resolution
    // Result: Canvas scales to all resolutions eliminating letterboxing
    // Requirements: Canvas  

    private RectTransform rt;
    private CanvasScaler cs;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        cs = gameObject.GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        // Compares width of Canvas RectTransform to the desired resolution. If it's wider, CanvasScaler scales to width
        if (rt.rect.width > cs.referenceResolution.x) cs.matchWidthOrHeight = 0;

        // Compares height of Canvas RectTransform to the desired resolution. If it's higher, CanvasScaler scales to height
        if (rt.rect.height > cs.referenceResolution.y) cs.matchWidthOrHeight = 1;

    }
}
