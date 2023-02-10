using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float spawnRate = 10;

    public bool enable;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),1, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        
        if (enable == true)
        {
            
            GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            
        }
        
    }
}
