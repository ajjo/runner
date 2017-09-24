using UnityEngine;
using System.Collections;
using UUEX;

namespace GameFramework
{
	public class DropTrigger : BaseMonoBehavior
	{
		public int _TriggerDelay = 10;

		private float mTime = 0.0f;
		private Collider mCollider;
		private IRunner mRunner;

		private void Start()
		{
			mCollider = GetComponent<Collider> ();
			mCollider.isTrigger = false;
			mRunner = ServiceLocator.GetService<IRunner> ();
		}

		public override void Update ()
		{
			base.Update ();

			if (!mCollider.isTrigger) 
			{
				mTime += Time.deltaTime;

				if (mTime >= _TriggerDelay) 
				{
					mCollider.isTrigger = true;
				}
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				mRunner.ResetCharacter ();
				mCollider.isTrigger = false;
				mTime = 0.0f;
			}
		}
	}
}
