using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Start()
    {
        Invoke("loadScene", 5f);
    }
    void loadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
