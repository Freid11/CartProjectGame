using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMassive : MonoBehaviour {
    public List<GameObject> Carts;
    public string[] sCarts = new string[] { "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart", "Cart" };
    private string PlayedCards = "";
    public GameObject SelectedCart { get; set; }

    void Start () {
        SelectedCart = null;
        Carts = Get_MassiveCart(sCarts);
        SuffleDec();
        Debug.Log("CartMassive Enter"+Carts.Count);
    }

    /// <summary>
    /// Устанавливаем новую карту на место сыграной 
    /// </summary>
    public void Set_CartsForPlay()
    {
        for (int i = 0; i < Carts.Count; i++)
        {
            ActCart CheckedCart = Carts[i].GetComponent<ActCart>();
            if (!CheckedCart.InAction && !CheckedCart.Defited)
            {
                if(SelectedCart!=null)
                //необходимо записать эту карту на позицию предыдущей карты
                    Carts[i].transform.SetPositionAndRotation(SelectedCart.transform.position,Quaternion.identity);
                SelectedCart = null;
                Carts[i].SetActive(true);
                break;
            }
        }
    }

    /// <summary>
    /// Возвращает карту, которая еще не была сыграна
    /// </summary>
    /// <returns></returns>
    public string Get_NextCart()
    {//необходимо получить следующую карту
        string Cart = null;
        int Index = Random.Range(0,sCarts.Length);
        while (PlayedCards.Contains("[" + Index + "]"))
        {
            Index = Random.Range(0, sCarts.Length);
        }
        if (Index > 0)
        {
            PlayedCards += "[" + Index + "]";
            Cart = sCarts[Index];
        }
        return Cart;
    }

    /// <summary>
    /// Перемешать колоду
    /// </summary>
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
            Result.Insert(0,Instantiate(Resources.Load(Cart, typeof(GameObject))) as GameObject);
            Result[0].SetActive(false);
        }
        return Result;
    }

	// Update is called once per frame
	void Update () {
        
	}
}
