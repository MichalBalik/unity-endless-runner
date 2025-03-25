using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMNG : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("ER",LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
