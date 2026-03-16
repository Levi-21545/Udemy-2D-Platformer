using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool isColected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;

                isColected = true;
                Destroy(gameObject);

                UIController.instance.UpdateGemCount();
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    
                    isColected = true;
                    Destroy(gameObject);
                }

            }
        }
    }
}
