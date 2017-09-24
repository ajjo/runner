using UnityEngine;
using System.Collections;
using UUEX;

namespace GameFramework
{
	public class CameraRunner : BaseMonoBehavior
	{
		public float _XOffset = 6.0f;
		public Transform _Character;
		public Transform _DropTrigger;
		public Transform _RespawnTrigger;

		public void Update()
		{
			Vector3 pos = transform.position;
			pos.x = _Character.transform.position.x + _XOffset;
			transform.position = pos;

			pos = _DropTrigger.transform.position;
			pos.x = transform.position.x;
			_DropTrigger.transform.position = pos;

			pos = _RespawnTrigger.transform.position;
			pos.x = transform.position.x - 20.0f;
			_RespawnTrigger.transform.position = pos;
		}
	}
}
