using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer;

    private MapPoint[] allPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allPoints = FindObjectsByType<MapPoint>(FindObjectsSortMode.None);

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }
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
        AudioManager.instance.PlaySFX(4);

        LSUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
