using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
	public static ButtonManager instance = null;
	public GameObject Title;
	public GameObject PlayButton;
	public GameObject ShopButton;
	public GameObject StanadardThemeButton;
	public GameObject InvertedThemeButton;
	public GameObject SpringThemeButton;

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
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Play()
	{
		StartCoroutine(LoadGame());
	}

	public void Shop()
	{
		StartCoroutine(LoadShop());
	}

	public void ChangeTheme(Themes theme)
	{
		StartCoroutine(LoadTheme(theme));
	}

	public void UnlockTheme()
	{
		Debug.Log("LOCKED!");
		
	}

	public IEnumerator LoadTheme(Themes theme)
	{
		ThemeManager.instance.ThemeToChangeTo = theme;
		GameManager.instance.Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Menu");
	}

	public IEnumerator LoadGame()
	{
		Title.GetComponent<Animator>().SetTrigger("LoadGame");
		PlayButton.GetComponent<Animator>().SetTrigger("LoadGame");
		ShopButton.GetComponent<Animator>().SetTrigger("LoadGame");
		GameManager.instance.Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Game");
	}
	public IEnumerator LoadShop()
	{
		Title.GetComponent<Animator>().SetTrigger("LoadGame");
		PlayButton.GetComponent<Animator>().SetTrigger("LoadGame");
		ShopButton.GetComponent<Animator>().SetTrigger("LoadGame");
		GameManager.instance.Fader.GetComponent<Animator>().SetTrigger("LeavingScene");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Shop");
	}


}