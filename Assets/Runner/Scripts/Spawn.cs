using UnityEngine;
using System.Collections;
using UUEX;

namespace GameFramework
{
	public class Spawn : BaseMonoBehavior
	{
		public Vector2 _MinOffset;
		public Vector2 _MaxOffset;
		public float _SpawnOffset = 80.0f;
		public GameObject[] _Objects;
		public Transform _ReferenceObject;

		private GameObject mSpawnedObject = null;
		private float mIncrement = 0.0f;

		public void Start()
		{
			Renderer renderer = _ReferenceObject.gameObject.GetComponent<Renderer> ();
			renderer.enabled = false;
			SpawnObject ();
		}
	
		public void SpawnObject()
		{
			if(mSpawnedObject != null)
			{
				Vector3 pos = mSpawnedObject.transform.localPosition;
				mIncrement = pos.x + _SpawnOffset;
				PoolManager.AddObject(mSpawnedObject.name,mSpawnedObject);
			}
				
			int randomIndex = Random.Range(0,_Objects.Length);
			mSpawnedObject = PoolManager.GetObject (_Objects [randomIndex].name);
			mSpawnedObject.SetActive (true);
			mSpawnedObject.transform.parent = _ReferenceObject;

			mSpawnedObject.transform.localPosition = new Vector3 (mIncrement + Random.Range(_MinOffset.x,_MaxOffset.x+1), Random.Range(_MinOffset.y,_MaxOffset.y+1), 0.0f);

			RunnerObject runnerObject = mSpawnedObject.GetComponent<RunnerObject> ();
			runnerObject.SetSpawn (this);
		}

		public void Respawn()
		{
			SpawnObject ();
		}
	}
}
