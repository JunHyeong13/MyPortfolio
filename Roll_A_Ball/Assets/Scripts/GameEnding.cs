using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    // fade effect time
    public float fadeDuration = 1f;
    // when fade effect begins, shows the Image until under the time. 
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup; 
    public AudioSource exitAudio;
    public AudioSource caughtAudio;


    // check the player exit the game
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;

    // Not to finish the game until the fade option ends.
    float m_Timer;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup,false, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
        
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        //exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }

    }
}
