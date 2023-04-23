using UnityEngine;

[RequireComponent(typeof(Camera))]
public class JumpCameraZoom : MonoBehaviour
{
    [Tooltip("The camera's zoom level when the player is not jumping.")]
    public float defaultZoom = 5f;

    [Tooltip("The camera's zoom level when the player is jumping.")]
    public float jumpZoom = 3f;

    [Tooltip("The player's transform component.")]
    public Transform playerTransform;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.orthographicSize = defaultZoom;
    }

    private void LateUpdate()
    {
        if (playerTransform.position.y > transform.position.y)
        {
            mainCamera.orthographicSize = jumpZoom;
        }
        else
        {
            mainCamera.orthographicSize = defaultZoom;
        }
    }
}