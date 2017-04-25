using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
	public Canvas GUICanvas;
	public Transform CameraOfPlayer;
	private Text textComponent;
	private Renderer rend;

	public string[] DialogueStrings;

	public float SecondsBetweenCharacters = 0.15f;
	public float CharacterApparitionRateMutliplier = 0.1f;

	public KeyCode DialogueInput = KeyCode.Space;

	//private bool shouldStart;
	private bool isStringBeingRevealed;
	private bool isDialoguePlaying;

	private bool isEndOfDialogue;
	public GameObject ContinueIcon;
	public GameObject StopIcon;

	void Start()
	{
		try
		{
			rend= transform.GetChild (0).transform.GetChild (6).GetComponent<Renderer>();
		}
		catch
		{
			rend = GetComponent<Renderer>();
		}
		textComponent = GUICanvas.GetComponentInChildren<Text> ();
		textComponent.text = "";

		HideIcons ();

	}


	void Update()
	{
		//GUICanvas.transform.LookAt (Player);
		/*Vector3 difference = Player.transform.position - GUICanvas.transform.position;
		float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
		GUICanvas.transform.rotation = Quaternion.Euler(0.0f,rotationY , 0.0f);*/
		if (rend.material.shader == Shader.Find ("Custom/NewSurfaceShader")) {
			if (gameObject.tag == "Interactive") {
				if (Input.GetKeyDown (KeyCode.F))
				{
					if (!isDialoguePlaying) 
					{
						isDialoguePlaying = true;
						StartCoroutine (StartDialogue ());
						//shouldStart = false;
					}
				}
			}
		}
	}

	void OnGUI()
	{
		if (rend.material.shader == Shader.Find ("Custom/NewSurfaceShader"))
			if (gameObject.tag == "Interactive")
				GUI.Box (new Rect (0, Screen.height - 30, 170, 25), "Press F to interact");
	}

	private IEnumerator StartDialogue()
	{
		int dialogueLenth = DialogueStrings.Length;
		int currentDialogueIndex = 0;

		while (currentDialogueIndex < dialogueLenth || !isStringBeingRevealed) 
		{
			if (!isStringBeingRevealed) 
			{
				isStringBeingRevealed = true;
				StartCoroutine (DisplayString (DialogueStrings[currentDialogueIndex++]));

				if (currentDialogueIndex >= dialogueLenth)
					isEndOfDialogue = true;
			}
			yield return 0;
		}

		while (true) 
		{
			if (Input.GetKeyDown (DialogueInput))
			{
				break;
			}
			yield return 0;
		}

		HideIcons ();
		isEndOfDialogue = false;
		isDialoguePlaying = false;
	}



	private IEnumerator DisplayString(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCharacterIndex = 0;

		HideIcons ();
		textComponent.text = "";

		while (currentCharacterIndex < stringLength) 
		{
			textComponent.text += stringToDisplay [currentCharacterIndex];
			currentCharacterIndex++;

			if (currentCharacterIndex < stringLength) 
			{
				if (Input.GetKey (DialogueInput))
					yield return new WaitForSeconds (SecondsBetweenCharacters * CharacterApparitionRateMutliplier);
				else
					yield return new WaitForSeconds (SecondsBetweenCharacters);
			}
			else
				break;
		}

		ShowIcons ();

		while (true) 
		{
			if (Input.GetKeyDown (DialogueInput))
			{
				break;
			}
			yield return 0;
		}

		HideIcons ();
		//shouldStart = false;
		isStringBeingRevealed = false;
		textComponent.text = "";
	}

	private void HideIcons()
	{
		ContinueIcon.SetActive (false);
		StopIcon.SetActive (false);
	}

	private void ShowIcons()
	{
		if (isEndOfDialogue) 
		{
			StopIcon.SetActive (true);
			return;
		}
		ContinueIcon.SetActive (true);
	}
}