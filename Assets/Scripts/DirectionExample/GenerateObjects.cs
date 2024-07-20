using UnityEngine;

[ExecuteInEditMode]
public class GenerateObjects : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] int _count;
    
    public void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            var position = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
            Instantiate(_player, position , transform.rotation, transform);
        }
    }
}
