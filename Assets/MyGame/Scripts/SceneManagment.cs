using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject pauseMenu;
    public GameObject player;

    void Start()
    {
        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        PauseMenu();
        EndMenu();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void EndMenu()
    {
        endMenu.SetActive(!endMenu.activeSelf);
    }
    public void Reset()
    {
        //TODO: Reset Player Stats
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!endMenu.activeSelf)
            {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            //TODO: Implement Pause Menu
            }
        }
        
        

    }
}
