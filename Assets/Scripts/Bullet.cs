using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed { get; set; }
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private SpriteRenderer sprite;
    private int group;
    public int Group { set { group = value; } }
    /// <summary>
    /// Физический урон от снаряда
    /// </summary>
    public int DamaPhysical { get; set; }
    /// <summary>
    /// Магический урон от снаряда
    /// </summary>
    public int DamaMagical { get; set; }
    /// <summary>
    /// Область поражения
    /// </summary>
    public float DamaSplash { get; set; }
    /// <summary>
    /// Граница поражения снаряда за этой границей он должен уничтожаться
    /// </summary>
    public float DamaRange { get; set; }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        ///надо уничтожать обьект если он встретился с другим обьектом или если он дости границы зоны обстрела
        Destroy(gameObject, 1.4f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character unit = collision.GetComponent<Character>();
        if (unit && unit.GroupID !=group)///получается у нас может быть как один игрок так и пати, если у нас пати, то надо их групировать чтобы урон по союзникам не шел...или все таки делать урон по союзникам тоже? 
        {
            Destroy(gameObject);
        }        
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed + Time.deltaTime);
	}
}
