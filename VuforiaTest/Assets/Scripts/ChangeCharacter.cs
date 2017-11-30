using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class User {
	public long device_number;
	public int level;
	public string nickname;
	public int hero_type;

	public User() {
	}

	public User(long device_number,int level, string nickname,int hero_type) {
		this.device_number = device_number;
		this.level = level;
		this.nickname = nickname;
		this.hero_type = hero_type;
	}
}

public class ChangeCharacter : MonoBehaviour {

	// Use this for initialization
	public bool isPrev;
	public bool isNext;
	private int index;
	private GameObject MediavalWarrior;
	private GameObject PrevMediavalWarrior;
	public GameObject nextButton;
	public GameObject prevButton;
	public GameObject Warrior;
	public Text WarriorName;
	DatabaseReference reference;
	void Start () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://encouraging-mix-96622.firebaseio.com/");
		reference = FirebaseDatabase.DefaultInstance.RootReference;

		//

		reference
			.GetValueAsync().ContinueWith(task => {
				if (task.IsFaulted) {
				}
				else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					if (snapshot.ChildrenCount !=0) {
						Application.LoadLevel ("GameScene");
					}
				}
			});

		if (PlayerPrefs.GetInt("index",-1)==-1) {
			PlayerPrefs.SetInt ("index", 1);
		}
		index = PlayerPrefs.GetInt ("index", -1);


	}
	public void ClickItem()
	{
		index = PlayerPrefs.GetInt ("index", -1);
		int prev_index = 1;
		if (isPrev && !isNext) {//prev button
			if (index>1) {
				prev_index = index;
				index--;
				PlayerPrefs.SetInt ("index", index);
			}

			foreach (Transform child in Warrior.transform) {
				if (child.gameObject.name == "Hero_" + prev_index) {
					PrevMediavalWarrior = child.gameObject;
				}
				else if (child.gameObject.name == "Hero_" + index) {
					MediavalWarrior = child.gameObject;
				}
			}
			MediavalWarrior.SetActive (true);
			PrevMediavalWarrior.SetActive (false);
			WarriorName.text = "Hero " + index;

			if (index == 1) {
				prevButton.SetActive (false);
				nextButton.SetActive (true);
			}
		}
		else if (isNext && !isPrev) {//next button
			if (index==7) {
				index =1;
			}

			if (index<7) {
				prev_index = index;
				index++;
				PlayerPrefs.SetInt ("index", index);
			}

			foreach (Transform child in Warrior.transform) {
				if (child.gameObject.name == "Hero_" + prev_index) {
					PrevMediavalWarrior = child.gameObject;
				}
				else if (child.gameObject.name == "Hero_" + index) {
					MediavalWarrior = child.gameObject;
				}
			}

			MediavalWarrior.SetActive (true);
			PrevMediavalWarrior.SetActive (false);
			WarriorName.text = "Hero " + index;
			if (index == 7) {
				prevButton.SetActive (true);
				nextButton.SetActive (false);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenScene()
	{
		int hero_type = PlayerPrefs.GetInt ("index", -1);
		User user = new User(356938035643809,1,"CemreOnur",hero_type);
		string json = JsonUtility.ToJson(user);
		reference.Child("encouraging-mix-96622").Child("0").SetRawJsonValueAsync(json);
		Application.LoadLevel ("GameScene");
	}
}
