using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] int howMany;
    [SerializeField] float distanceBetween;

    float _xMin;
    float _xMax;
    // Start is called before the first frame update
    void Start()
    {
        _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        float yPos = transform.position.y;
        int i;
        for (i = 0; i < howMany; i++){
            Instantiate(_enemyPrefab, new Vector3(Random.Range(_xMin, _xMax), yPos, 0), Quaternion.identity);
            yPos += distanceBetween;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
