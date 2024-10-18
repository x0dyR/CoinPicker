using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    public int Value => _value;

    [field: SerializeField] private int _maxValue;
    [field: SerializeField] private int _minValue;

    private int _value;

    private SphereCollider _collider;

    private void Awake()
        => _collider = GetComponent<SphereCollider>();

    private void OnEnable()
        => _value = Random.Range(_minValue, _maxValue);

}
