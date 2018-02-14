using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPLayField : MonoBehaviour {

    CartMassive MassOfCarts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //значит надо проверить есть ли у нас выбранные карты
        }
        if (Input.GetMouseButtonUp(0))
        {
            //необходимо установить персонажей(определенное их количество) на поле
            MassOfCarts = FindObjectOfType<CartMassive>();
            if (MassOfCarts.SelectedCart)
            {//если у нас есть выбранная карты, нам необходимо привязать ее к ближайшей башне
            }
        }
	}
}
