using UnityEngine;

public class TargetFolower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _offsetX;

    private Vector3 _newPosition;

    private void FixedUpdate()
    {
        Folow();
    }

    private void Folow()
    {
        _newPosition.x = _target.transform.position.x + _offsetX;
        _newPosition.z = transform.position.z;
        transform.position = _newPosition;
    }
}