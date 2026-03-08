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
            ChangeColor(enemyRenderer);
        }
        
        ChangeColor(_renderer);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"OnTriggerExit2D: {other.gameObject.name}");
        
        if (other.TryGetComponent(out SpriteRenderer enemyRenderer))
        {
            ChangeColor(enemyRenderer);
        }
        
        ChangeColor(_renderer);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"OnTriggerStay2D: {other.gameObject.name}");
    }

    private void ChangeColor(SpriteRenderer spriteRenderer)
    {
        Color currentColor = spriteRenderer.color;

        if (currentColor == Color.red)
        {
            spriteRenderer.color = Color.green;
        }
        else if (currentColor == Color.green)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            Debug.LogError($"Current Player color: {currentColor}");
        }
        
        Debug.Log($"Current color for {spriteRenderer.gameObject.name} is {spriteRenderer.color}");
    }
}
