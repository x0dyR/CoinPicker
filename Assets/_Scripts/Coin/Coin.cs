using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    public int Value { get; private set; }

    [field: SerializeField] private int _maxValue;
    [field: SerializeField] private int _minValue;

    private SphereCollider _collider;

    private void Awake()
        => _collider = GetComponent<SphereCollider>();

    public void RandomizeValue()
        => Value = Random.Range(_minValue, _maxValue);

}
