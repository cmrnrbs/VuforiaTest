using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
public class LoadCharacter : MonoBehaviour {

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

	// Use this for initialization
	public GameObject Warrior;
	private GameObject MyHero;
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
						string d= "";
					/*	long device_number = long.Parse(snapshot.Value["encouraging-mix-96622"][0]["device_number"]);
						int hero_type = int.Parse(snapshot.Value["encouraging-mix-96622"][0]["hero_type"]);
						string nickname = snapshot.Value["encouraging-mix-96622"][0]["nickname"];
						int level = int.Parse(snapshot.Value["encouraging-mix-96622"][0]["level"]);*/
						long device_number = long.Parse(string.Format("{0}", snapshot.Child("encouraging-mix-96622/0/device_number").Value));
						int level = int.Parse(string.Format("{0}", snapshot.Child("encouraging-mix-96622/0/level").Value));
						int hero_type = int.Parse(string.Format("{0}", snapshot.Child("encouraging-mix-96622/0/hero_type").Value));
						string NickName = snapshot.Child("encouraging-mix-96622/0/nickname").Value.ToString();
						string d2 = "";

						foreach (Transform child in Warrior.transform) {
							if (child.gameObject.name == "Hero_" + hero_type) {
								MyHero = child.gameObject;
								//child.gameObject.transform.GetChild(3).GetComponent<Text>().text = NickName;
							
							}
						}


						MyHero.gameObject.SetActive(true);
						Component[] hingeJoints;

						hingeJoints = MyHero.GetComponentsInChildren(typeof(TextMesh));

						if (hingeJoints != null)
						{
							foreach (TextMesh joint in hingeJoints)
								joint.text =NickName;
						}
					}
				}
			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
