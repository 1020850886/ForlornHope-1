using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friend : MonoBehaviour {
    GameObject selected;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void select(GameObject selected)
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).GetComponent<test>().isSelect = false;
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
        this.selected = selected;
    }
    void attack(GameObject target)
    {
        if (selected == null) return;
        if ((target.transform.position - selected.transform.position).magnitude > selected.GetComponent<test>().range) return;
        if (selected.GetComponent<test>().isAttack == true) return;
        selected.GetComponent<test>().isAttack = true;
        target.GetComponent<test>().damage(selected.GetComponent<test>().attack);
    }
    public void next()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<test>().isSelect = false;
            transform.GetChild(i).GetComponent<test>().isAttack = false;
            transform.GetChild(i).GetComponent<test>().move = 0;
            transform.GetChild(i).GetComponent<test>().refresh();
        }
    }
}
