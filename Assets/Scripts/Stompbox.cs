using UnityEngine;

public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;
    [Range(0, 100)] public float chanceToDrop;

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
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Stomped");

            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0f, 100f);

            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
    }
}
