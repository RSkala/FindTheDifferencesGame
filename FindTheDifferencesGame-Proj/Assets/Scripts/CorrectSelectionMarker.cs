using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class CorrectSelectionMarker : MonoBehaviour
{
    Collider2D _collider2d;
    SpriteRenderer _spriteRenderer;
    CorrectSelectionMarkerPair _parentCorrectSelectionMarkerPair;
    
    public void Init(CorrectSelectionMarkerPair parentCorrectSelectionMarkerPair)
    {
        _parentCorrectSelectionMarkerPair = parentCorrectSelectionMarkerPair;
    }

    public void MakeVisibleAndUnselectable()
    {
        _spriteRenderer.enabled = true;
        _collider2d.enabled = false;
    }

    void Start()
    {
        // Start the collider as enabled so it can be clicked by the user
        _collider2d = GetComponent<Collider2D>();
        _collider2d.enabled = true;

        // Start the spriterenderer as disable so it cannot be seen by the user
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    void Update()
    {
        
    }

    public void OnSelected()
    {
        _parentCorrectSelectionMarkerPair.NotifySelected();
    }
}
