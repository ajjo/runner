using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UUEX;

namespace GameFramework
{
	public interface IRunner
	{
		void AddDamage(int damage);
		void GameOver();
		void Restart();
		void UpdateLastGoodPosition (Vector3 pos);
		void ResetCharacter();
	}

	public class RunnerMain : BaseMonoBehavior,IRunner
	{
		public string _HighscoreKey = "HIGHSCORE";
		public UIGame _UIGame;
		public UIGameOver _UIGameOver;
		public Transform _Character;
		public float _ScoreMultiplier = 1.0f;
		public int _MaxDamage = 30;
		public int _MaxLives = 3;

		private int mScore = 0;
		private int mHighscore = 0;

		private float mCharacterStartPoint;
		private float mDistance = 0;
		private int mDamage = 0;
		private int mHealth = 0;
		private Vector3 mLastGoodCharacterPosition;
		private int mLivesLeft;

		public override void Awake ()
		{
			base.Awake ();
			mLivesLeft = _MaxLives;

			ServiceLocator.AddService (typeof(IRunner), this);
		}

		public void Start()
		{
			mCharacterStartPoint = _Character.transform.position.x;
			mHealth = 100;
			
			if (PlayerPrefs.HasKey (_HighscoreKey))
			{
				mHighscore = PlayerPrefs.GetInt (_HighscoreKey);
				_UIGame.UpdateHighscore (mHighscore);
			}

			_UIGame.UpdateHealth (mHealth);
			_UIGame.UpdateLives (mLivesLeft);
		}

		public void AddDamage(int damage)
		{
			mDamage += damage;
 			mHealth = Mathf.CeilToInt (100 - ((mDamage / (float)_MaxDamage) * 100.0f));

			_UIGame.UpdateHealth (mHealth);

			if (mHealth <= 0)
				GameOver ();
		}

		public void GameOver()
		{
			Time.timeScale = 0;

			if(mScore > mHighscore)
			{
				PlayerPrefs.SetInt (_HighscoreKey, mScore);
				PlayerPrefs.Save();
			}

			_UIGameOver.SetVisibility (true);
		}

		public void UpdateLastGoodPosition(Vector3 pos)
		{
			mLastGoodCharacterPosition = pos;
		}

		public void ResetCharacter()
		{
			Time.timeScale = 1;
			_Character.transform.position = mLastGoodCharacterPosition;
			mLivesLeft -= 1;
			
			_UIGame.UpdateLives (mLivesLeft);
			
			if (mLivesLeft <= 0)
				GameOver ();
		}

		public override void Update ()
		{
			base.Update ();

			float currentPosition = _Character.transform.position.x;
			float diff = currentPosition - mCharacterStartPoint;
			float distanceCovered = Mathf.Sqrt (diff * diff);

			int score = Mathf.CeilToInt (distanceCovered * _ScoreMultiplier);
			mScore = score;
			_UIGame.Updatescore (score);
		}

		public void Restart()
		{
			Time.timeScale = 1;
			ServiceLocator.Clear ();
			PoolManager.Clear ();
			Application.LoadLevel ("Runner");
		}
	}
}
