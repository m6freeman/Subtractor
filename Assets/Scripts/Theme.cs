using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Theme", menuName = "Theme")]
public class Theme : ScriptableObject
{

	public Themes Name;
	public Sprite Background;
	public Sprite Fade;
	public Sprite Title;
	public Sprite TitleBackground;
	public Sprite PlayButton;
	public Sprite ShopButton;
	public Sprite Star;
	public Sprite LevelTransitionScrollBar;
	public List<Sprite> TotalsLit;
	public List<Sprite> TotalsDim;
	public List<Sprite> ButtonsUp;
	public List<Sprite> ButtonsDown;
	public Color TextColor;
	public Font TextFont;

	
}
