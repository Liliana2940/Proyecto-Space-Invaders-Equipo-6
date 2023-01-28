using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    private void OnTriggerEnter2D(Collider2D collision) => Destroy(gameObject);

    private void Update()
    {
        if (gameObject.tag == "Laser")
            transform.Translate(this.speed * Time.deltaTime * Vector3.up);
        if (gameObject.tag == "Missile")
            transform.Translate(this.speed * Time.deltaTime * Vector3.down);
    }
}
