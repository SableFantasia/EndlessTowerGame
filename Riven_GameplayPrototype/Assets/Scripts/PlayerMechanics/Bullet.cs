using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float bulletLifeTime;

    public void Update()
    {
        bulletLifeTime += Time.deltaTime;

        if(bulletLifeTime >= 2 && gameObject != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        Debug.Log(collision.gameObject.name);
    }
}
