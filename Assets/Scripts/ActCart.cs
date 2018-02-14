using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ActCart : MonoBehaviour {

    private bool isCheck = false;
    [Header("Персонаж")]
    public GameObject Character;
    [Range(1, 100)]
    public int NumberOfCaracter;
    public bool InAction;//Чтобы не выводить карты которые уже были запущены
    public bool Defited;//чтобы помечать битые карты

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
                CartMassive CartMass = FindObjectOfType<CartMassive>();
                CartMass.SelectedCart = gameObject;
                //Debug.Log("Выбрали карту {"+gameObject.transform.position.x+"} "+"{"+gameObject.transform.position.y+"}");
                isCheck = true;
            }
    }
}
