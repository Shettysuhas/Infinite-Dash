using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GroundPlane : MonoBehaviour
{
    GroundSpawnner groundSpawn;
    public GameObject obstacle;
    private float laneCoinSpawn = -2.5f;

    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawnner>();
       
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawn.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    
    public void obstacleSpawnner()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coins;
    public void CoinSpawn()
    {

        int coinSpawn = 5;
        for (int i = 0; i < coinSpawn; i++)
        {
            GameObject temp = Instantiate(coins);
            temp.transform.position = GetRandomPointCollider(GetComponent<Collider>());
        }
               
    }


    Vector3 GetRandomPointCollider(Collider collider)
    {
       

        Vector3 point = new Vector3(laneCoinSpawn,
           Random.Range(collider.bounds.min.y, collider.bounds.max.y), Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        point.y = 1;
        laneCoinSpawn += 2.5f;
        if (laneCoinSpawn == 5)
        {
            laneCoinSpawn = -2.5f;
        }
        return point;
    }

    
}
