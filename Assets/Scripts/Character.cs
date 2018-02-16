using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Character : MonoBehaviour {
    
	[Header("Персонаж")]
	public int Heals;
	[Range(10,100)]
	public float SpeedMove;
	public Sprite TextureCart;
	public int Exp = 5;
    public int GroupID;

	[Header("Атака")]
	[Range(10,1500)]
	public int atPhysical;
	[Range(10,1500)]
    public int atMagic;
    public int atCriticalDamage;
    public float atCriticalDamageChance;
	[Range(1,5)]
	public float atRange;
    private SphereCollider colRangeAttack;
	public bool atSplash;
    public float atSplashRange;
	[Range(10,100)]
	public float atSpeed;
	public RangeAttackEnum atType;

	[Header("Защита")]
	[Range(10,100)]
    public int defPhysical;
	[Range(10,100)]
    public int defMagic;

    private Bullet bullet;
    private Character AttackedEnemy; 

	public void Start(){
		
	}

    /// <summary>
    /// Засчитывает урон персонажу от выстрела
    /// </summary>
    /// <param name="bullet">Выстрел от которого необходимо засчитать урон</param>
    public void Receive_Damage(Bullet bullet)
    {
        Heals -= defMagic - bullet.DamaMagical;
        Heals -= defPhysical - bullet.DamaPhysical;
    }

    private void Shoot()
    {
        Vector3 pos = transform.position;
        
        Bullet NewShoot = Instantiate(bullet,pos,bullet.transform.rotation)as Bullet;
        NewShoot.DamaMagical = atMagic;
        NewShoot.DamaPhysical = atPhysical;
        NewShoot.DamaSplash = 
        NewShoot.Group = GroupID;
    }
   
   	public void Awake(){
        colRangeAttack = GetComponent<SphereCollider>();
        colRangeAttack.radius = atRange;
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet)
        {
            Receive_Damage(bullet);
        }
    }

    /// <summary>
    /// Класс атаки
    /// </summary>
	public enum RangeAttackEnum{Near, Far};
    /// <summary>
    /// Тип атаки
    /// </summary>
    public enum TypeAttacEnum { Magic, Physical }
}
