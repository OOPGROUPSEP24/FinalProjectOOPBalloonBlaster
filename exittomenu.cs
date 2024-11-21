using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Eve

public class exittomenu : MonoBehaviour
{
 public void OpenMainMenu()
{
    SceneManager.LoadSceneAsync("mainmenufinal"); // Use the actual name of your Main Menu scene
}
}
