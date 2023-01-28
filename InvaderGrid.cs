using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderGrid : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    
    private Vector3 _direction = Vector2.right;
    public AnimationCurve speed;
    public Projectile missilePrefab;
    public int invadersLeft => totalInvaders - invadersDestroyed;
    public int invadersDestroyed { get; private set; }
    public int totalInvaders => this.rows * this.columns;
    public float percentDestroyed => (float)this.invadersDestroyed / (float)this.totalInvaders;
    public void InvaderDestroyed() => this.invadersDestroyed++;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns -1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2 (-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            for (int columns = 0; columns < this.columns; columns++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                invader.destroyed += InvaderDestroyed;
                Vector3 position = rowPosition;
                position.x += columns * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(this.percentDestroyed) * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x -1.0f))
            {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x +1.0f))
            {
                AdvanceRow();
            }
        }
    }
    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
}
