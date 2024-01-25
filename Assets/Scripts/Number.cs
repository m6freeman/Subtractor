using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{

    public Theme Theme;

	public Animation thisAnimation;
	public bool activeState = true;
	public List<Sprite> activeSprites;
	public List<Sprite> inactiveSprites;

	public int value;
	public int inColumn;
	public int inRow;
	public bool addToTotal;

	private int _rand;
	private bool _animPlayed;
	Transform trans;
	BoxCollider2D boxCol;

	// Use this for initialization

	void Awake()
	{
		trans = GetComponent<Transform>();
		boxCol = GetComponent<BoxCollider2D>();
		ChangeTheme();
		_rand = Random.Range(0, activeSprites.Count - GameManager.instance.NumberRangeDifficulty);
		_animPlayed = false;
		value = _rand + 1;
		thisAnimation = GetComponent<Animation>();
	}
	void Start()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = activeSprites[_rand];
		ThemeManager.ThemeChangeDelegate += ChangeTheme;

		// Scale settings for Spring Theme
		// if (ThemeManager.instance.ThemeToChangeTo == Themes.Spring) 
		// {
		// 	trans.localScale = new Vector3( 0.4f, 0.4f, 1 );
		// 	boxCol.offset = new Vector2( 0, 0.25f );
		// 	boxCol.size = new Vector2( 1.75f, 2 );
		// }

	}

	// Update is called once per frame
	void Update()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = activeState ? activeSprites[_rand] : inactiveSprites[_rand];
		if (!_animPlayed)
		{
			StartCoroutine(AnimationHesitation(thisAnimation));
			_animPlayed = true;
		}
	}

	void ChangeTheme()
	{
		activeSprites.Clear();
		inactiveSprites.Clear();
		foreach (var activeSprite in ThemeManager.instance.AppliedTheme.GetComponent<Theme>().ButtonsUp) activeSprites.Add(activeSprite);
		foreach (var inactiveSprite in ThemeManager.instance.AppliedTheme.GetComponent<Theme>().ButtonsDown) inactiveSprites.Add(inactiveSprite);
	}

	void OnMouseUp()
	{
		Grid.NumberOfMovesPlayerHasMade++;
		activeState = !activeState;
		value = activeState ? _rand + 1 : 0;
		Grid.GetColumnAndRowTotals();
	}

	IEnumerator AnimationHesitation(Animation anim)
	{
		float ElapsedTime = 0f;
		float Timer = Random.Range(1, 9);
		while (ElapsedTime < Timer)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			ElapsedTime += Time.deltaTime * 100;
			if (ElapsedTime >= Timer)
			{
				anim.Play();
				yield break;
			}
		}

	}

	private void OnDisable() {
		ThemeManager.ThemeChangeDelegate -= ChangeTheme;
	}

}