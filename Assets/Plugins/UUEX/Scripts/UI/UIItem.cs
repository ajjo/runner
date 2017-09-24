using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace UUEX.UI
{
	public class UIItem : UIItemBase
	{
		public bool _Interactive = true;
		public bool _Visible = true;

		public AudioClip _ClickSound;

		private UI mUI;
		private System.Object mItemData;
		private AudioSource mAudioSource = null;

		public override void Start()
		{
			base.Start ();

			Image image = GetComponent<Image> ();
			if(image != null && image.sprite != null)
			{
				Texture2D atlas = image.sprite.texture;
				ResourceManager.AddAtlas(atlas, image.sprite);
			}

			// Add a listenr when the cull state changes
			MaskableGraphic maskableGraphic = GetComponent<MaskableGraphic> ();
			if(maskableGraphic != null)
				maskableGraphic.onCullStateChanged.AddListener(OnCullStateChanged);

			mAudioSource = EventSystem.current.gameObject.GetComponent<AudioSource> ();
		}

		// This is for the individual items
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(mUI != null)
				mUI.OnItemClick (this);

			if(mAudioSource != null)
			{
				mAudioSource.clip = _ClickSound;
				mAudioSource.Play();
			}
		}

		public virtual bool IsVisible()
		{
			return transform.gameObject.activeSelf;
		}
		
		public virtual void SetVisibility(bool visibility)
		{
			transform.gameObject.SetActive(visibility);
		}

		public virtual void Enable()
		{
			Graphic [] graphics = gameObject.GetComponentsInChildren<Graphic> ();
			foreach (Graphic graphic in graphics)
				graphic.enabled = true;

			Selectable [] selectables = gameObject.GetComponentsInChildren<Selectable> ();
			foreach (Selectable selectable in selectables)
				selectable.interactable = true;
		}

		public virtual void Disable()
		{
			Graphic [] graphics = gameObject.GetComponentsInChildren<Graphic> ();
			foreach (Graphic graphic in graphics)
				graphic.enabled = false;
			
			Selectable [] selectables = gameObject.GetComponentsInChildren<Selectable> ();
			foreach (Selectable selectable in selectables)
				selectable.interactable = false;
		}

		public void SetParent(UI parentUI)
		{
			mUI = parentUI;
		}

		public bool HasName(string itemName)
		{
			return (GetName().Equals (itemName));
		}

		public string GetName()
		{
			return transform.name;
		}

		public void SetName(string itemName)
		{
			transform.name = itemName;
		}

		public void SetPosition(Vector3 pos)
		{
			SetPosition (pos.x, pos.y);
		}

		public void SetPosition(Vector2 pos)
		{
			SetPosition (pos.x, pos.y);
		}

		public void SetPosition(float x, float y)
		{
			RectTransform rectTransform = GetComponent<RectTransform> ();
			Vector3 localPosition = rectTransform.localPosition;
			localPosition.x = x;
			localPosition.y = y;
			rectTransform.localPosition = localPosition;
		}

		public virtual void SetInteractive(bool interactive)
		{

		}

		public virtual void SetDisabled(bool disabled)
		{

		}

		public void SetScale(Vector2 scale)
		{
			transform.localScale = scale;
		}

		public void SetScale(float x, float y)
		{
			Vector3 scale = transform.localScale;
			scale.x = x;
			scale.y = y;
			transform.localScale = scale;
		}

		public void SetRotation(float eulerAngleZ)
		{
			transform.Rotate (0.0f, 0.0f, eulerAngleZ);
		}

		public void SetRotation(Vector3 eulerAngle)
		{
			transform.Rotate (eulerAngle);
		}

		public void SetItemData(System.Object data)
		{
			mItemData = data;
		}

		public System.Object GetItemData()
		{
			return mItemData;
		}

		public UIItem Clone()
		{
			GameObject clonedGameObject = GameObject.Instantiate (transform.gameObject);
			UIItem newItem = clonedGameObject.GetComponent<UIItem> ();
			return newItem;
		}

		public UIItem Clone(string newItemName)
		{
			UIItem newItem = Clone ();
			newItem.SetName (newItemName);
			return newItem;
		}

		private void OnCullStateChanged(bool culled)
		{
			if(mUI != null)
				mUI.OnCullStateChanged (this, culled);
		}
	}
}
