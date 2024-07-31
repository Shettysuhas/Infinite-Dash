using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float rotateSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>())
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.OnCoinCollected?.Invoke();
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime);
    }
}
