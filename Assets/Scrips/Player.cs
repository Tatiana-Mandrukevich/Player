using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D: {other.gameObject.name}");
        
        // other.gameObject.GetComponent<SpriteRenderer>();

        if (other.TryGetComponent(out SpriteRenderer enemyRenderer))
        {
            ChangeColor(_renderer, enemyRenderer);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"OnTriggerExit2D: {other.gameObject.name}");
        
        if (other.TryGetComponent(out SpriteRenderer enemyRenderer))
        {
            ChangeColor(_renderer, enemyRenderer);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"OnTriggerStay2D: {other.gameObject.name}");
    }

    private void ChangeColor(SpriteRenderer playerSpriteRenderer, SpriteRenderer enemySpriteRenderer)
    {
        Color playerCurrentColor = playerSpriteRenderer.color;
        Color enemyCurrentColor = enemySpriteRenderer.color;
        
        Color playerNewColor = enemyCurrentColor;
        Color enemyNewColor = playerCurrentColor;
        
        playerSpriteRenderer.color = playerNewColor;
        enemySpriteRenderer.color = enemyNewColor;
        
        Debug.Log($"Current color for {playerSpriteRenderer.gameObject.name} is {playerSpriteRenderer.color}");
        Debug.Log($"Current color for {enemySpriteRenderer.gameObject.name} is {enemySpriteRenderer.color}");
    }
}