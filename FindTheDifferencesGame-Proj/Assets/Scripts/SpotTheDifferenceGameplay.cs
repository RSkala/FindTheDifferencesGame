using UnityEngine;
using UnityEngine.InputSystem;

public class SpotTheDifferenceGameplay : MonoBehaviour
{
    [SerializeField] GameObject _incorrectSelectionMarkerPrefab;

    Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnClick(InputValue inputValue)
    {
        Vector2 mousePosition2D = Mouse.current.position.value;
        Vector3 mousePosition3D = new Vector3(mousePosition2D.x, mousePosition2D.y, mainCamera.nearClipPlane);
        Vector3 mouseWorldPoint = mainCamera.ScreenToWorldPoint(mousePosition3D);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(mouseWorldPoint, mainCamera.transform.forward);
        if(raycastHit2D.collider != null)
        {
            GameObject clickedGameObject = raycastHit2D.collider.gameObject;
            Debug.Log("clickedGameObject: " + clickedGameObject.name);
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.CorrectSelection);
        }
        else
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.IncorrectSelection);

            // Spawn the "incorrect selection" marker at the clicked point
            GameObject incorrectSelectionMarker = Instantiate<GameObject>(_incorrectSelectionMarkerPrefab);
            incorrectSelectionMarker.transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, 0.0f);
        }
    }
}
