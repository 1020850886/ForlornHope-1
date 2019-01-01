using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void AIMove()
    {
      for (int i = 0; i < transform.childCount; i++)
        {
            Transform temp = GameObject.Find("friend").transform.GetChild(0);
            for (int j = 0; j < GameObject.Find("friend").transform.childCount; j++)
            {
                if ((GameObject.Find("friend").transform.GetChild(j).position - transform.GetChild(i).position).magnitude > (temp.position - transform.GetChild(i).position).magnitude)
                {
                    temp = GameObject.Find("friend").transform.GetChild(j);
                } 
            }
            transform.GetChild(i).GetComponent<test>().setTarget(temp.position);
        }
    }

    void end()
    {
        GameObject.Find("friend").GetComponent<friend>().next();
        AIMove();
        next();
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
