using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEvolution : MonoBehaviour
{
    public int killThreshold = 3; // Number of enemies to kill per evolution
    public int maxEvolutions = 3; // Maximum number of evolution stages
    public List<Sprite> evolutionSprites; // List of sprites for each evolution stage

    private int currentEvolution = 0;
    private int kills = 0;
    private SpriteRenderer spriteRenderer;
    
    public float newSize = 5f; // Yeni kamera boyutu
    public Camera targetCamera; 
    
    // Define the trigger radius variable
    public float triggerRadius = 1.0f; // Adjust this value as needed
    public string ScenceName;
    
    public Vector3 additionalScale = new Vector3(0.2f, 0.2f, 0.2f); // Ek olarak uygulanacak ölçek değeri
    public Vector3 additionalScaleforBox = new Vector3(1f, 1f, 1f); // Ek olarak uygulanacak ölçek değeri
    private BoxCollider boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();

      
    }

    void Update()
    {
        // Check for enemy death within trigger radius
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, triggerRadius);
       

        foreach (Collider2D enemyCollider in enemiesHit)
        {
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log("Found enemy: " + enemyCollider.gameObject.name);
                if (enemyHealth.IsDead()) // Ensure EnemyHealth has IsDead method
                {
                   
                    kills++;
                    CheckForEvolution();
                    enemyHealth.GetComponent<EnemyHealth>()?.Die();
                }
            }
        }
    }

    void CheckForEvolution()
    {
        Debug.Log("Cehecking for EVO");
        if (kills >= killThreshold && currentEvolution < maxEvolutions)
        {
           
            kills -= killThreshold; // Reset kill count for next evolution
            currentEvolution++;
            spriteRenderer.sprite = evolutionSprites[currentEvolution];

            // Update other relevant player attributes (optional)
            // e.g., increase movement speed, firing rate, damage, etc.
             UpdatePlayerStats(currentEvolution);
        }
    }

    // Optional function to update player stats based on evolution level
    void UpdatePlayerStats(int currentEvolution)
    {
        // Implement logic to modify player stats based on evolution level
        switch (currentEvolution)
        {
            case 1:
                ChangeCameraSize(7f,targetCamera);
                SclaeUpdaet();
                break;
            case 2:
                ChangeCameraSize(9f,targetCamera);
                SclaeUpdaet();
                break;
            case 3:
                ChangeCameraSize(10f,targetCamera);
                SclaeUpdaet();
                break;
            case 4:
                LoadSceneByName(ScenceName);
                break;
            default:
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
    
    void ChangeCameraSize(float newSize, Camera camera)
    {
        camera.orthographicSize = newSize;
    }
    public void LoadSceneByName(string sceneName)
    {
        // SceneManager.LoadScene() fonksiyonu ile adı verilen sahneyi yükle
        SceneManager.LoadScene(sceneName);
    }

    void SclaeUpdaet()
    {
        // Oyun nesnesinin mevcut ölçeğini al
        Vector3 currentScale = transform.localScale;

        // Ek ölçeği mevcut ölçeğe ekle
        Vector3 newScale = currentScale + additionalScale;

        // Oyun nesnesinin ölçeğini güncelle
        transform.localScale = newScale;
    }

    void BoxScaleUpdate()
    {
       
            // Mevcut boyutları al
            Vector3 currentSize = boxCollider.size;

            // Ek ölçeği mevcut boyutlara ekle
            Vector3 newSize = currentSize + additionalScale;

            // BoxCollider'ın boyutlarını güncelle
            boxCollider.size = newSize;
        
    }
}
