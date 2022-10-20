using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile missilePrefab;
    public float speed = 5.0f;
    private bool _missileActive;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (!_missileActive)
        {
            Projectile projectile = Instantiate(this.missilePrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += MissileDestroyed;
            _missileActive = true;
        }
    }
    private void MissileDestroyed()
    {
        _missileActive = false;
    }
}
