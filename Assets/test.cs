using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
 public float health = 10;
    public float attack = 5;
    public float maxMove = 5;
    public float range = 5;

    public float move = 0;
    public bool isAttack = false;
    public bool isSelect = false;
    public bool AIisOn = false;
    public Vector2 target;

	// Use this for initialization
	void Start () {
        if (transform.parent.name == "enemy"){
            AIisOn = true;
            target = transform.position;
        }

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.localPosition.y);
        if (isSelect)
        {
            Vector2 delta = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) / 20;
            move += delta.magnitude;
            if (move < maxMove) transform.position += (Vector3)delta;
        }
        else
        {
        }
        if (AIisOn)
        {
            Vector2 delta = (target - (Vector2)transform.position) / (target - (Vector2)transform.position).magnitude / 10;
            move += delta.magnitude;
            if (move < maxMove) transform.position += (Vector3)delta;
        }
	}

    public void setTarget(Vector2 target)
    {
        this.target = target;
    }
    public void select()
    {
    }
    private void OnMouseDown()
    {
        if (AIisOn == false) friend();
        else enemy();
    }
    public void enemy()
    {
        GameObject.Find("friend").SendMessage("attack", gameObject);
    }
    public void friend()
    {
        transform.parent.SendMessage("select",gameObject);
        isSelect = true;
        GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);

    }
    public void damage(float damage)
    {
        this.health -= damage;
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.7f, 0.7f);
        Invoke("refresh", 0.3f);
        if (health < 0)
        {
            Invoke("dead", 0.3f);
        }
    }
    public void refresh()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
    }
    public void dead()
    {
        Destroy(gameObject);
    }
}
