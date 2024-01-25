using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public int RandomSeed
	{
		get { return PlayerPrefs.GetInt("RandomSeed"); }
		set { PlayerPrefs.SetInt("RandomSeed", value); }
	}
	public int CurrentLevel
	{
		get { return PlayerPrefs.GetInt("CurrentLevel"); }
		set { PlayerPrefs.SetInt("CurrentLevel", value); }
	}
	public int Stars;
	public int Columns = 6;
	public int Rows = 6;
	public int NumberRangeDifficulty;
	public int NumberAddedToTotalDifficulty;
	public GameObject ThisLevelsGrid;
	public Text LevelCounterText;

	// Update will try to find this object if Null && in Game scene
	public GameObject EndLevelAnimPanel;
	public GameObject Star;
	public GameObject LevelOneInstructions;
	public GameObject LevelTwoInstructions;
	public static bool PerfectScore = false;
	public static bool starPanelisUp = false;
	public float RestartStarPenalty = 0.75f;
	public GameObject Fader;

	// Ad Information
	public string BannerAdID = "bannerAd";
	public string StoreID = "3070796";

	// Use this for initialization

	void Awake()
	{
		if (null == instance)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		CurrentLevel = (CurrentLevel > 0) ? CurrentLevel : 1;
		RandomSeed = (RandomSeed > 0) ? RandomSeed : 1;
		Stars = (PlayerPrefs.GetInt("Stars"));
		UnityEngine.Random.InitState(GameManager.instance.RandomSeed);
		Monetization.Initialize(StoreID, false);
		Advertisement.Initialize(StoreID, false);
	}

	void Start()
	{
		LevelCounterText = GameObject.Find("LevelCounter").GetComponent<Text>();
		
	}

	// Update is called once per frame
	void Update()
	{
		UnityEngine.Random.InitState(GameManager.instance.RandomSeed);
		if (ThisLevelsGrid == null && SceneManager.GetActiveScene().name == "Game") Instantiate(ThisLevelsGrid);
		LevelModifications(CurrentLevel, out Columns, out Rows, out NumberRangeDifficulty, out NumberAddedToTotalDifficulty);
		if (LevelCounterText != null) LevelCounterText.text = CurrentLevel.ToString();
		if (CurrentLevel == 1 && SceneManager.GetActiveScene().name == "Game") LevelOneInstructions.SetActive(true);
		if (CurrentLevel == 2 && SceneManager.GetActiveScene().name == "Game") LevelTwoInstructions.SetActive(true);

		if (SceneManager.GetActiveScene().name != "Menu")
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				StartCoroutine(Back());
			}
		}	

		if (EndLevelAnimPanel == null && SceneManager.GetActiveScene().name == "Game") EndLevelAnimPanel = GameObject.Find("LevelTransitionScrollBar");


	}

	public IEnumerator Back()
	{
		Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		if (starPanelisUp) starPanelisUp = false;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("Menu");
	}

	public IEnumerator NextLevel()
	{
		// When Game Scene is reloaded, Grid script's Update checks to see if all Totals are satisfied
		// If they are, they invoke NextLevel method. First we check to see if the puzzle was already solved
		// by random-chance by checking for dividebyzero exception (there was no moves the player could make)
		// and if so, reload the scene again with new random seed. Do this until puzzle doesn't solve itself
		try { float test = Grid.LowestPossibleMoves / Grid.NumberOfMovesPlayerHasMade; }
		catch (DivideByZeroException ex)
		{
			Debug.Log(ex);
			++RandomSeed;
			SceneManager.LoadScene("Game");
			yield break;
		}

		// Increment Random's seed so it doesn't generate the same puzzle twice
		++RandomSeed;
		
		// Display instructions. Instruction scripts activate gameobject if they are on the appropirate level
		if (LevelOneInstructions.activeSelf) LevelOneInstructions.GetComponentInChildren<Animator>().SetBool("FadeOut", true);
		if (LevelTwoInstructions.activeSelf) LevelTwoInstructions.GetComponentInChildren<Animator>().SetBool("FadeOut", true);
		
		// Evaluate whether the player has performed the minimum number of moves to solve the puzzle
		PerfectScore = (Grid.LowestPossibleMoves / Grid.NumberOfMovesPlayerHasMade == 1);
		// Increment the level counter
		++CurrentLevel;
		// apply modifications based on the current level and return out to local properties
		LevelModifications(CurrentLevel, out Columns, out Rows, out NumberRangeDifficulty, out NumberAddedToTotalDifficulty);
		LevelCounterText.text = CurrentLevel.ToString();
		Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		GameManager.instance.Star.SetActive(PerfectScore);
		EndLevelAnimPanel.GetComponent<Animation>().Play();
		yield return new WaitForSeconds(1.75f);
		if (PerfectScore) Stars++;
		PlayerPrefs.SetInt("Stars", Stars);
		if (starPanelisUp) starPanelisUp = false;
		yield return new WaitForSeconds((PerfectScore) ? 1.5f : 0.5f);
		SceneManager.LoadScene("Game");

	}

	public IEnumerator Reset()
	{
		if (LevelOneInstructions.activeSelf) LevelOneInstructions.GetComponentInChildren<Animator>().SetBool("FadeOut", true);
		if (LevelTwoInstructions.activeSelf) LevelTwoInstructions.GetComponentInChildren<Animator>().SetBool("FadeOut", true);
		EndLevelAnimPanel = GameObject.Find("LevelTransitionScrollBar");
		CurrentLevel = RandomSeed = 1;
		PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
		EndLevelAnimPanel.GetComponent<NextLevelAnimation>().Resetting = true;
		LevelModifications(CurrentLevel, out Columns, out Rows, out NumberRangeDifficulty, out NumberAddedToTotalDifficulty);
		LevelCounterText.text = CurrentLevel.ToString();
		Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		EndLevelAnimPanel.GetComponent<Animation>().Play();
		Stars -= (int) (Stars * RestartStarPenalty);
		PlayerPrefs.SetInt("Stars", Stars);
		if (starPanelisUp) starPanelisUp = false;
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Game");
	}

	private void LevelModifications(int level, out int columns, out int rows, out int numberRangeDifficulty, out int numberAddedToTotalDifficulty)
	{
		if (level > 0 && level <= 3)
		{
			columns = 2;
			rows = 2;
		}
		else if (level > 3 && level <= 8)
		{
			columns = 3;
			rows = 2;
		}
		else if (level > 8 && level <= 15)
		{
			columns = 3;
			rows = 3;
		}
		else if (level > 15 && level <= 25)
		{
			columns = 4;
			rows = 3;
		}
		else if (level > 25 && level <= 50)
		{
			columns = 4;
			rows = 4;
		}
		else if (level > 50 && level <= 100)
		{
			columns = 5;
			rows = 4;
		}
		else if (level > 100 && level <= 250)
		{
			columns = 5;
			rows = 5;
		}
		else if (level > 250 && level <= 500)
		{
			columns = 6;
			rows = 5;
		}
		else
		{
			columns = 6;
			rows = 6;
		}

		numberAddedToTotalDifficulty = (level < 5) ? 5 : 2;

		if (Stars % 7 == 0)
		{
			numberRangeDifficulty = 5;
		}
		else if (Stars % 5 == 0)
		{
			numberRangeDifficulty = 4;
		}
		else if (Stars % 3 == 0)
		{
			numberRangeDifficulty = 2;
		}
		else if (Stars % 2 == 0)
		{
			numberRangeDifficulty = 1;
		}
		else
		{
			numberRangeDifficulty = 0;
		}
	}

	public void LoadBannerAd()
	{
		if (!Advertisement.Banner.isLoaded)
		{
			Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
			if (Advertisement.IsReady(BannerAdID)) Advertisement.Banner.Show(BannerAdID);
			else Debug.Log("Not Ready");
		}
	}

	public void HideBannerAd()
	{
		if (Advertisement.Banner.isLoaded)
		{
			Advertisement.Banner.Hide();
		}
	}

}