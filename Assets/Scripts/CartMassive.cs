using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMassive : MonoBehaviour {
    public GameObject[] Carts;
    public GameObject CartPosition1;
    public GameObject CartPosition2;
    public GameObject CartPosition3;
    public GameObject CartPosition4;
    public GameObject CartPosition5;

    void Start () {
        GameObject cart = Instantiate(Resources.Load("Cart", typeof(GameObject))) as GameObject;
        if (cart != null)
        {
            Instantiate(cart, CartPosition1.transform.position, CartPosition1.transform.rotation);
        }
        
	}

    public GameObject[] Get_MassiveCart()
    {
        GameObject[] Result = new GameObject[] { };
        return Result;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
