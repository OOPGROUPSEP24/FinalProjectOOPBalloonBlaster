using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //fasya

public class gameoverxbutton : MonoBehaviour
{
public void OpenMainMenu()
{
    SceneManager.LoadSceneAsync("mainmenufinal"); // Use the actual name of your Main Menu scene
}
}
