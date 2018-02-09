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

	[Header("Атака")]
	[Range(10,1500)]
	public int atPhysical;
	[Range(10,1500)]
    public int atMagic;
    public int atCriticalDamage;
	[Range(1,5)]
	public float atRange;
    private SphereCollider colRangeAttack;
	public bool atSplash;
	[Range(10,100)]
	public float atSpeed;
	public TypeAttackEnum atType;

	[Header("Защита")]
	[Range(10,100)]
    public int defPhysical;
	[Range(10,100)]
    public int defMagic;

	void Start(){
		
	}

   	public void Awake(){
        colRangeAttack = GetComponent<SphereCollider>();
        colRangeAttack.radius = atRange;
    }

	public enum TypeAttackEnum{Near, Far};
}
