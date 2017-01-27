using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;



public class CreateNewSceneWizard : ScriptableWizard {

	public enum TypeOfScene
	{
		LEVEL, OTHER
	};

	public string sceneName = "Name of the Scene";
	public TypeOfScene typeOfScene = TypeOfScene.LEVEL;

	[MenuItem("Wander Tools/Create New Scene")]
	static void CreateNewScene(){
		ScriptableWizard.DisplayWizard<CreateNewSceneWizard> ("Create New Scene", "Create");
	}

	/**
	 * Checks the status of the current scene, creates a new scene filling it and saves it with the correct name
	 */
	void OnWizardCreate(){
		EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ();

		EditorSceneManager.NewScene (NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

		// Find default objects
		GameObject mainCamera = GameObject.Find("Main Camera");
		GameObject directionalLight = GameObject.Find ("Directional Light");

		// Structure
		GameObject _management = new GameObject ("Management");
		GameObject _GUI = new GameObject ("GUI");
		GameObject _cameras = new GameObject ("Cameras");
		mainCamera.transform.parent = _cameras.transform;
		GameObject _lights = new GameObject ("Lights");
		directionalLight.transform.parent = _lights.transform;
		GameObject _world = new GameObject ("World");
		GameObject _terrain = new GameObject ("Terrain");
		_terrain.transform.parent = _world.transform;
		GameObject _props = new GameObject ("Props");
		_props.transform.parent = _world.transform;
		GameObject _dynamic = new GameObject ("_Dynamic");

		string sceneTypeFolderName = "";
		switch (typeOfScene) {
		case TypeOfScene.LEVEL:
			sceneTypeFolderName = "Levels";
			break;
		case TypeOfScene.OTHER:
			sceneTypeFolderName = "Others";
			break;
		default:
			sceneTypeFolderName = "Others";
			break;
		};

		EditorSceneManager.SaveScene (EditorSceneManager.GetActiveScene (), "Assets/Scenes/" + sceneTypeFolderName + "/" + toCamelCase(sceneName) + ".unity");
	}

	/** 
	 * Update the helpString with the real name of the scene.
	 */
	void OnWizardUpdate(){
		helpString = "Scene Name: " + toCamelCase (sceneName);
	}

	/** 
	 * Turns the phrase in a camel case string 
	 */
	string toCamelCase(string phrase) {
		string[] splittedPhrase = phrase.Split(' ', '-', '.');
		string resultPhrase = "";

		foreach (string s in splittedPhrase) {
			char[] spllitedPhraseChars = s.ToCharArray ();
			if (spllitedPhraseChars.Length > 0) {
				spllitedPhraseChars [0] = char.ToUpper(spllitedPhraseChars[0]);
			}
			resultPhrase += new string (spllitedPhraseChars);
		}
	
		return resultPhrase;
	}
}
