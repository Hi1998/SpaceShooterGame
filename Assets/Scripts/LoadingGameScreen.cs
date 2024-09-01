using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGameScreen : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
