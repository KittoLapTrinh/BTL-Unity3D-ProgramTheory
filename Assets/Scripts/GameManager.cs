using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public enum Cars { Convertible, CompactCar_Police, CompactCar_Taxi, SharkTruck }

	[System.Serializable]
	public class HighscoreData {
		public System.TimeSpan convertibleScore;
		public System.TimeSpan policeScore;
		public System.TimeSpan taxiScore;
		public System.TimeSpan sharkScore;
	}

	public static GameManager Instance { get; private set; } // ENCAPSULATION
	public static bool IsGameOver { get; set; } // ENCAPSULATION
	public static bool IsGameStarted { get; set; } // ENCAPSULATION

	public Cars choosenCarType;
	public GameObject player;
	public HighscoreData highscoreData = new HighscoreData();

	private void Awake() {
		if (Instance != null) {
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public bool IsSelectedVehicle(Cars cRef) { // ABSTRACTION
		if (cRef == choosenCarType) return true;
		else return false;
	}

	private bool IsScoreLowerThan(System.TimeSpan score1, System.TimeSpan score2) { // ABSTRACTION
		if (score1 < score2)
			return true;
		else
			return false;
	}

	public void SaveHighscore(System.TimeSpan score, Cars cRef) { // ABSTRACTION
		HighscoreData data = highscoreData;

		switch (cRef) {
			case Cars.Convertible:
				if (highscoreData.convertibleScore == new System.TimeSpan() ||
					IsScoreLowerThan(score, highscoreData.convertibleScore)
				)
					data.convertibleScore = score;
				break;
			case Cars.CompactCar_Police:
				if (highscoreData.policeScore == new System.TimeSpan() ||
					IsScoreLowerThan(score, highscoreData.policeScore)
				)
					data.policeScore = score;
				break;
			case Cars.CompactCar_Taxi:
				if (highscoreData.taxiScore == new System.TimeSpan() ||
					IsScoreLowerThan(score, highscoreData.taxiScore)
				)
					data.taxiScore = score;
				break;
			case Cars.SharkTruck:
				if (highscoreData.sharkScore == new System.TimeSpan() ||
					IsScoreLowerThan(score, highscoreData.sharkScore)
				)
					data.sharkScore = score;
				break;
		}

		highscoreData = data;
	}
}
