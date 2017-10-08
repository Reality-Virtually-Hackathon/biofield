using UnityEngine;
using System.Collections;

public class MiscSpawnSphere : MonoBehaviour {
    public GameObject[] miscItems;

    public float spawnRate; // per second

    public float minSpeed = 2;
    public float maxSpeed = 20;

    public float minSize = .1f;
    public float maxSize = 10;

    public float minSpawnDist = 0;

    public float maxInScene = 200;
    private MeshRenderer sphereMesh;

    int cycleArray = 0;

    Rigidbody rb;
    void Awake()
    {
         sphereMesh = GetComponent<MeshRenderer>();
    }

    void Start () {
        sphereMesh.enabled = false;
        StartCoroutine(SpawnMisc());
    }

    public Vector3 RandomScale()
    {
        float randomFloat = Random.Range(minSize, maxSize);
        Vector3 randomScale = new Vector3(randomFloat, randomFloat, randomFloat);
        return randomScale;
    }

    public float RandomForce()
    {
        return Random.Range(minSpeed * 100, maxSpeed * 100);
    }
    
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    public void CycleCheck()
    {
        cycleArray++;
        if (cycleArray >= miscItems.Length)
        {
            cycleArray = 0;
        }
    }

    public float VectorAdd(Vector3 scale)
    {
        return (scale.x + scale.y + scale.z) * 100000;
    }

    IEnumerator SpawnMisc()
    {
        CycleCheck();
        GameObject miscItemClone = (GameObject)Instantiate(miscItems[cycleArray], RandomCircle(transform.position, Random.Range(minSpawnDist, transform.localScale.y / 2)), Random.rotation);
        miscItemClone.transform.localScale = RandomScale();
        rb.AddForce(transform.forward * RandomForce());
        rb.mass = VectorAdd(miscItemClone.transform.localScale);
        yield return new WaitForSeconds(1 / spawnRate);
        rb = miscItemClone.GetComponent<Rigidbody>();
        StartCoroutine(SpawnMisc());
    }
}
