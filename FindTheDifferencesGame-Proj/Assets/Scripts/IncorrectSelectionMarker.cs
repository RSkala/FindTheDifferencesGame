using UnityEngine;

public class IncorrectSelectionMarker : MonoBehaviour
{
    [Tooltip("Amount of time an 'Incorrect Selection Marker' remains on-screen")]
    [SerializeField] float _timeOnScreen;

    float _timeAlive = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        _timeAlive += Time.deltaTime; 
        if(_timeAlive >= _timeOnScreen)
        {
            Destroy(gameObject);
        }
    }
}
