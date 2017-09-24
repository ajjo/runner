using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using UUEX;

/// <summary>
/// Weapon.
/// Weapons functionality attached to the Player and Enemy ship
/// </summary>
public class Weapon : BaseMonoBehavior
{
	public string _WeaponName;
	public float _CoolDownTime;
	public float _Speed;
	public int _Damage;
	public int _Point;
	public string _BulletName;
	public int _Level;
	public int _Direction = 1;

	private float mTime = 0.0f;

	public void Fire(Vector3 startPosition)
	{
		GameObject obj = PoolManager.GetObject (_BulletName);
		Bullet bullet = obj.GetComponent<Bullet> ();
		bullet._Weapon = this;
		obj.SetActive (true);
		obj.transform.parent = null;
		obj.transform.position = startPosition;
		obj.name = _BulletName;
	}

	public void Update()
	{
		mTime += Time.deltaTime;
		
		if (mTime >= _CoolDownTime) 
		{
			mTime = 0.0f;
			Vector3 startPos = transform.position;
			startPos.x += 2.0f;
			
			Fire(startPos);
		}
	}
}
