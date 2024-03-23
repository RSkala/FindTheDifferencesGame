using UnityEngine;
using UnityEngine.InputSystem;

public class SpotTheDifferenceGameplay : MonoBehaviour
{
    Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnClick(InputValue inputValue)
    {
        Vector3 mousePosition = Mouse.current.position.value;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector3 mouseWorldPoint = mainCamera.ScreenToWorldPoint(mousePosition);

        RaycastHit2D raycastHit2D = Physics2D.Raycast(mouseWorldPoint, mainCamera.transform.forward);
        if(raycastHit2D.collider != null)
        {
            GameObject clickedGameObject = raycastHit2D.collider.gameObject;
            Debug.Log("clickedGameObject: " + clickedGameObject.name);
        }
    }
}
