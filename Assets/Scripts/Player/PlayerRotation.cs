using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _minRotationValue;
    [SerializeField] private float _maxRotationValue;
    [SerializeField] private float _rotationSpeed;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        Rotate();
    }

    public void SetMaxRotation()
    {
        transform.rotation = _maxRotation;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Init()
    {
        _minRotation = Quaternion.Euler(0, 0, _minRotationValue);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationValue);
    }
}
