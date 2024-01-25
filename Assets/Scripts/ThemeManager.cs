using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ThemeManager : ScriptableObject
{

}


public class ThemeManager : MonoBehaviour {

    public static ThemeManager instance = null;

    private Themes _currentTheme;
    public Themes ThemeToChangeTo;
    public GameObject AppliedTheme;
    public List<GameObject> AllThemes;
    public delegate void OnThemeChange();
    public static event OnThemeChange ThemeChangeDelegate;


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

        string str = PlayerPrefs.GetString("CurrentTheme", null);
        if (string.IsNullOrEmpty(str) == true) PlayerPrefs.SetString("CurrentTheme", Themes.Standard.ToString());
        _currentTheme = (Themes)Enum.Parse(typeof(Themes), PlayerPrefs.GetString("CurrentTheme"), true);
        ThemeToChangeTo = _currentTheme;
        ApplyTheme();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTheme != ThemeToChangeTo)
        {
            _currentTheme = ThemeToChangeTo;
            PlayerPrefs.SetString("CurrentTheme", _currentTheme.ToString());
            ApplyTheme();
            ThemeChangeDelegate();
        }
    }



    //   public Theme[] AllThemes;
    //   public Theme AppliedTheme;

    //   private Themes _currentTheme;

    void ApplyTheme()
    {
        AppliedTheme = AllThemes.Where(theme => theme.GetComponent<Theme>().Name == _currentTheme).Single();
    }



}
	


