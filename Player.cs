using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject missilePrefab;
    public float speed = 5.0f;
    private bool _missileActive;
    public int playerHP;

    private void Shoot()
    {
        if (!_missileActive)
        {
            Instantiate(missilePrefab, transform.position, Quaternion.identity);
            _missileActive = true;
        }

        else
        {
            _missileActive = false;
        }
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHP -= 1;
        if (this.playerHP <= 0)
        {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
