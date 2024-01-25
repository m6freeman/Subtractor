using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image m_image;
    public float fadeSpeed;
    public bool m_fading;

    void Start() 
    {
        
    }

    void Update()
    {
        if (m_fading) m_image.CrossFadeAlpha(1, fadeSpeed, false);

        if (!m_fading) m_image.CrossFadeAlpha(0, fadeSpeed, false);
    }

    private void OnGUI()
    {
        m_fading = !m_fading;   
    }

}