using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _angle;
    
    private void Update()
        => transform.Rotate(Vector3.up, _angle * Time.deltaTime);
}
