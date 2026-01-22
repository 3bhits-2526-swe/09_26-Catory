using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject pauseMenu;
    public GameObject player;

    private GameObject[] vrObjects;
    private GameObject[] realObjects;

    void Start()
    {
        vrObjects = GameObject.FindGameObjectsWithTag("VR");
        realObjects = GameObject.FindGameObjectsWithTag("RL");
        foreach (GameObject obj in vrObjects)
        {
            obj.SetActive(false);
        }


        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        PauseMenu();
        ToggleVR();
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

    public void Resume()
    {
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
    }

    public void ToggleVR()
    {
        if (Input.GetKeyDown("space"))
        {
            if(vrObjects[0].activeSelf == false)
            {
                foreach (GameObject obj in vrObjects)
                {
                    obj.SetActive(true);
                }
                foreach (GameObject obj in realObjects)
                {
                    obj.SetActive(false);
                }
            }
            else if(vrObjects[0].activeSelf == true)
            {
                foreach (GameObject obj in vrObjects)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in realObjects)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
