using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float xOffset;

    private void LateUpdate()
    {
        transform.position = NewPosition(target.position.x);
    }

    private Vector3 NewPosition(float xPox)
    {
        return new Vector3(xPox + xOffset, transform.position.y, transform.position.z);
    }
}
