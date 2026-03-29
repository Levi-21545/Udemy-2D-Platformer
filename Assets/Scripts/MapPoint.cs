using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;

    public string levelToLoad, levelToCheck, levelName;

    public int gemsCollected, totalGems;
    public float bestTime, targetTime;

    public GameObject gemBadge, timeBadge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToLoad + "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if (gemsCollected >= totalGems && totalGems > 0)
            {
                gemBadge.SetActive(true);
            }

            if (bestTime > 0 && bestTime <= targetTime)
            {
                timeBadge.SetActive(true);
            }

            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }

            if (levelToCheck == levelToLoad)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
