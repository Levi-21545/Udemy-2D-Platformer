using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public string levelSelect, mainMenu;

    public GameObject pauseScreen;
    public bool isPaused;

	public void Awake()
	{
        instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
            AudioManager.instance.bgm.Play();
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isPaused = true;
            AudioManager.instance.bgm.Stop();
        }
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }
}
