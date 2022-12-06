using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    AnimationCurve spawningCurve;
    [SerializeField]
    List<GameObject> enemyType = new();
    float time;
    float lastSpawn;

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
                enemy = Instantiate(enemyType[0], hitInfo.point, Quaternion.identity, transform);
                //for (int j = 0; j < enemyType.Count; j++) {}
            }
            //Debug.Log(Mathf.RoundToInt(spawningCurve.Evaluate(time / 120f) * 50));
        }
    }
}
