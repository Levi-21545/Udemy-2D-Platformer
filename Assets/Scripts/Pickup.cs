using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool isColected;

    public GameObject pickupEffect;

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

                Instantiate(pickupEffect, transform.position, pickupEffect.transform.rotation);

                UIController.instance.UpdateGemCount();

                AudioManager.instance.PlaySFX(6);
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isColected = true;
                    Destroy(gameObject);

                    Instantiate(pickupEffect, transform.position, pickupEffect.transform.rotation);

                    AudioManager.instance.PlaySFX(7);
                }
            }
        }
    }
}
