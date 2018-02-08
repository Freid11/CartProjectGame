using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActCart : MonoBehaviour {

    private bool isCheck = false;
    public GameObject Character;


	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            if (isCheck)
            {
                goCheckCart();
            }
            ClickMouse();
            
        }
	}

    void ClickMouse() {
        RaycastHit rch = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rch))
        {
            if (rch.collider.gameObject == gameObject)
            {
                goCheckCart();
            }
        }
       
    }

    public void goCheckCart() {

          if (isCheck)
            {
                gameObject.transform.position = gameObject.transform.position + Vector3.down;
                isCheck = false;
            }
            else
            {
                gameObject.transform.position = gameObject.transform.position + Vector3.up;
                isCheck = true;
            }
    }
}
