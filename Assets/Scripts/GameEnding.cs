using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float displayImageDuration = 1.0f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackGroundImageCanvasGroup;
    public AudioSource caughtAudio;


    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;
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

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackGroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(!m_HasAudioPlayed )
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
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
