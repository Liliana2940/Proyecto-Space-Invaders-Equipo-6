using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }
}