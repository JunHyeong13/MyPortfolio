using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    // fade effect time
    public float fadeDuration = 1f;
    // when fade effect begins, shows the Image until under the time. 
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    // check the player exit the game
    bool m_IsPlayerAtExit;

    // Not to finish the game until the fade option ends.
    float m_Timer;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
