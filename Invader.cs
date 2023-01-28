using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public System.Action destroyed;
    public float animationTime = .25f;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public int invaderHP;

    public GameObject laserPrefab;
    public float invaderAR = 1.0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        InvokeRepeating(nameof(InvaderAttack), this.invaderAR, this.invaderAR);
    }

    private void AnimateSprite()
    {
        _animationFrame++;
        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        invaderHP -= 1;
        if (this.invaderHP <= 0)
        {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator InvaderAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < (1.0f / 55))
            {
                Instantiate(this.laserPrefab, invader.position, Quaternion.identity);
                break;
            }
        }
        yield return null;
    }
}
