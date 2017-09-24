using UnityEngine;
using System.Collections;
using UUEX;

namespace GameFramework
{
	public class RunnerObject : BaseMonoBehavior
	{
		public Transform _WeaponObject;

		private Spawn mSpawn;
		private IRunner mRunner;

		public void Start()
		{
			mRunner = ServiceLocator.GetService<IRunner> ();
		}

		public override void Update ()
		{
			base.Update ();
		}

		public void SetSpawn(Spawn spawn)
		{
			mSpawn = spawn;
		}

		void OnCollisionEnter(Collision collision)
		{
			if(gameObject.layer != LayerMask.NameToLayer("RotatingObject") && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				Vector3 pos = transform.position;
				mRunner.UpdateLastGoodPosition (pos);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			// The moving platform has a funky setup... this trigger is only for that.
			if(gameObject.layer != LayerMask.NameToLayer("RotatingObject") && other.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				Vector3 pos = transform.position;
				mRunner.UpdateLastGoodPosition (pos);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("RespawnTrigger"))
			{
				mSpawn.Respawn ();
			}
		}
	}
}
