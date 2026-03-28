using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        LSUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad); 
    }
}
