using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Total : MonoBehaviour {

	public bool columnRowComplete;

	public int inColumn;
	public int inRow;

	public List<Sprite> LitTotals;
	public List<Sprite> DimTotals;

	public int Value;

	Transform trans;

	// Use this for initialization
	void Start () 
	{
		trans = GetComponent<Transform>();
		ChangeTheme();
		ThemeManager.ThemeChangeDelegate += ChangeTheme;
		gameObject.GetComponent<SpriteRenderer>().sprite = (columnRowComplete) ? LitTotals[Value + 1] : DimTotals[Value + 1];
		//if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) trans.localScale = new Vector3( 0.5f, 0.5f, 1 );
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (inColumn > 0)
		{
			columnRowComplete = Grid.columnValue[inColumn - 1] == Value;
		}
		if (inRow > 0)
		{
			columnRowComplete = Grid.rowValue[inRow - 1] == Value;
		}

		gameObject.GetComponent<SpriteRenderer>().sprite = (columnRowComplete) ? LitTotals[Value] : DimTotals[Value];

	}

	void ChangeTheme()
	{
		LitTotals.Clear();
		DimTotals.Clear();
		foreach (var litSprite in ThemeManager.instance.AppliedTheme.GetComponent<Theme>().TotalsLit) LitTotals.Add(litSprite);
		foreach (var dimSprite in ThemeManager.instance.AppliedTheme.GetComponent<Theme>().TotalsDim) DimTotals.Add(dimSprite);

	}
		private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}
}
