using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    AnimationCurve spawningCurve;
    [SerializeField]
    List<GameObject> enemyType = new();
    public IObjectPool<GameObject> enemiesPool;
    float time;
    float lastSpawn;

    private void Awake()
    {
        enemiesPool = new ObjectPool<GameObject>(CreateEnemy, OnGet, OnRelease, OnDestroyPool, maxSize: 300);
    }

    GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyType[0]);
        enemy.GetComponent<EnemyHealth>().SetPool(enemiesPool);
        return enemy;
    }

    void OnGet(GameObject obj)
    {
        obj.SetActive(true);
    }
    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyPool(GameObject obj)
    {
        Destroy(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= lastSpawn + 1f)
        {
            lastSpawn = Time.time;
            SpawnEnemies();
        }
    }



    void SpawnEnemies()
    {
        GameObject enemy;
        if (transform.childCount < 300)
        {
            for (int i = 0; i < spawningCurve.Evaluate(time / 120f) * 50; i++)
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(Random.Range(1f, 1.1f), Random.Range(0f, 1), 0));
                Physics.Raycast(ray, out RaycastHit hitInfo, 500, 128);
                enemy = enemiesPool.Get();
                enemy.transform.position = hitInfo.point;
                enemy.transform.SetParent(transform);
            }
            //Debug.Log(Mathf.RoundToInt(spawningCurve.Evaluate(time / 120f) * 50));
        }
    }
}
