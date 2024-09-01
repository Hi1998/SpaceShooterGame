using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGameScreen : MonoBehaviour
{

    /// <summary>
    /// Here we load the Game Screen on clicking the play button
    /// </summary>
    public void StartTheGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
