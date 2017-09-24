using UnityEngine;
using System.Collections;
using GameFramework;
using UUEX;

/// <summary>
/// Bullet
/// Bullet fired from a weapon
/// </summary>
public class Bullet : BaseMonoBehavior
{
	[System.NonSerialized]
	public Weapon _Weapon;
	private IRunner mRunner;

	public void Start()
	{
		mRunner = ServiceLocator.GetService<IRunner> ();
	}

	void Update()
	{
		Vector3 pos = transform.position;
		pos.x += (_Weapon._Speed * Time.deltaTime) * _Weapon._Direction;
		transform.position = pos;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			mRunner.AddDamage(_Weapon._Damage);
			//Debug.Log ("It hit " + other.gameObject.name);
		}
	}

	void OnTriggerExit(Collider other)
	{
		//Debug.Log ("Bullet exit");
		PoolManager.AddObject (_Weapon._BulletName, gameObject);
	}
}
