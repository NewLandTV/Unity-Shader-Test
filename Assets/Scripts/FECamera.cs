using UnityEngine;

public class FECamera : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField]
    private Vector3 destinationPosition;

    private float timer;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPosition, destinationPosition, timer);
        timer += Time.deltaTime * 0.5f;
    }
}
