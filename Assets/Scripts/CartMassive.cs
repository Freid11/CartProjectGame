using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMassive : MonoBehaviour {
    public List<GameObject> Carts;
    public string[] sCarts = new string[] { "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart" };
    public GameObject CartPosition1;
    public GameObject CartPosition2;
    public GameObject CartPosition3;
    public GameObject CartPosition4;
    public GameObject CartPosition5;

    void Start () {
        Carts=Get_MassiveCart(sCarts);
        SuffleDec();
	}

    /// <summary>
    /// Выводим карту на экран
    /// </summary>
    public void Show_Cart()
    {
        Instantiate(Carts[0], CartPosition1.transform.position, CartPosition1.transform.rotation);
        Instantiate(Carts[1], CartPosition2.transform.position, CartPosition2.transform.rotation); 
        Instantiate(Carts[2], CartPosition3.transform.position, CartPosition3.transform.rotation); 
        Instantiate(Carts[3], CartPosition4.transform.position, CartPosition4.transform.rotation);
        Instantiate(Carts[4], CartPosition5.transform.position, CartPosition5.transform.rotation);
    }

    private void SuffleDec()
    {
        Random rnd = new Random();
        List<GameObject> RandomizedCards = new List<GameObject>(Carts.Count);
        string AddedIndexes = "";
        for (int i = 0; i < Carts.Count; i++)
        {
            int Index = Random.Range(0,Carts.Count);
            while(AddedIndexes.Contains("["+Index+"]"))
            {
                Index = Random.Range(0,Carts.Count);
            }
            AddedIndexes+="["+Index+"]";
            RandomizedCards.Add(Carts[Index]);
        }
        Carts = RandomizedCards;
    }

    /// <summary>
    /// Заполняем массив карт из префабов по именам карт
    /// </summary>
    /// <param name="sCarts">Массив имен карт, которые необходимо вывести</param>
    /// <returns></returns>
    public List<GameObject> Get_MassiveCart(string[] sCarts)
    {
        List<GameObject> Result = new List<GameObject>() ;
        foreach (string Cart in sCarts)
        {
            Result.Add(Instantiate(Resources.Load(Cart, typeof(GameObject))) as GameObject);
        }
        return Result;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
