using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;
    // Update is called once per frame
    void Update()
    {
        if (enemy == null) {
            Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            enemy = Instantiate(enemyPrefab) as GameObject;
            Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            if(enemyRenderer != null) {
                enemyRenderer.material.color = randomColor;
            }
            enemy.transform.localScale = new Vector3(.5f, Random.Range(0.5f, 1f), .5f);
            enemy.transform.position = new Vector3(0, 0, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
