using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// HardyWeinberg includes a number of wrapper methods that link to methods that quiz panels have buttons which connect to.
// The player, upon entering an answer, sends that answer to the appropriate method which checks that answer.  If it is 
// correct, it initiates the transformation of the sheep.  If not, it gives an error message.

public class HardyWeinberg : MonoBehaviour {
		
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate lightningbolt.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate lightningbolt.
	BattleMessageHandler messageHandler;
	public GameObject quizPanel; // The main quiz object under which all the quizes and inputs rest as children/
	public GameObject input; // The following are the inputs of all the inputs for the quiz panels.
	public GameObject input2;
	public GameObject input3;
	public GameObject input4;
	public GameObject input5;
	public GameObject input6;
	public GameObject timeStormCluster; // The storm cinematic that plays when quiz is correctly answered.
	
	void Start () {
		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;
	}

	// The following are all wrapper methods, since buttons must link to methods with void returns.
	public void runCheckAnswer(){
		StartCoroutine (checkAnswer ());
	}

	public void runCheckAnswer2(){
		StartCoroutine (checkAnswer2 ());
	}

	public void runCheckAnswer3(){
		StartCoroutine (checkAnswer3 ());
	}

	public void runCheckAnswer4(){
		StartCoroutine (checkAnswer4 ());
	}

	public void runCheckAnswer5(){
		StartCoroutine (checkAnswer5 ());
	}

	public void runCheckAnswer6(){
		StartCoroutine (checkAnswer6 ());
	}

	//
	// The following are all of the answers that correspond to the quizes (1-6)
	public IEnumerator checkAnswer(){
	
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal; // Used in case the quiz is succesful and the sheep transforms.
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator; // Used to initiate transformation animation.

		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;

		string answer = input.GetComponent<InputField>().text; // The string input of the player's answer.

		if (string.IsNullOrEmpty (answer)) // If the player enters nothing, set the answer to zero to avoid a null exception.
			answer = "0";

		if (answer == "25%") // If the player uses a percentage sign, remove that sign.
			answer = "25";

		int ansNum;

		if (int.TryParse(answer, out ansNum)) { // Try to parse the answer into an integer.
			if (ansNum ==25){ // The answer is correct.

			gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000); // Moves the quiz out of the way so that it can continue its functions but appears to have been destroyed.

			messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3)); // Start instantiation of TimeStorm animation/
				yield return new WaitForSeconds (.5f); // Brief pause to summon storm.
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7); // Length of storm animation.

				// Actual transformation of player's animal.
					// If the player is one element, convert them to the other.
					if (player.getElement () == element.electricity) { 
						player.changeElement (element.ice);
						changeAnimation.SetTrigger ("Breed");
					} else {
						player.changeElement (element.electricity);
						changeAnimation.SetTrigger ("Breed");
					}
					messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
				}else // Actual number input, but the number is wrong.
					messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else // Something other than a number is input.
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}

	public IEnumerator checkAnswer2(){
		
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
		
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		
		string answer = input2.GetComponent<InputField>().text;
		
		if (string.IsNullOrEmpty (answer)) 
			answer = "0";

		if (answer == "25%")
			answer = "25";

		int ansNum;
		
		if (int.TryParse(answer, out ansNum)) {
			if (ansNum ==25){
				
				gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000);
				
				messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3));
				yield return new WaitForSeconds (.5f);
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7);
				
				// If the player is one element, convert them to the other.
				if (player.getElement () == element.electricity) { 
					player.changeElement (element.ice);
					changeAnimation.SetTrigger ("Breed");
				} else {
					player.changeElement (element.electricity);
					changeAnimation.SetTrigger ("Breed");
				}
				messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
			}else
				messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}

	public IEnumerator checkAnswer3(){
		
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
		
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		
		string answer = input3.GetComponent<InputField>().text;
		
		if (string.IsNullOrEmpty (answer)) 
			answer = "0";
		
		float ansNum;
		
		if (float.TryParse(answer, out ansNum)) {
			if (ansNum ==.50f){
				
				gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000);
				
				messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3));
				yield return new WaitForSeconds (.5f);
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7);
				
				// If the player is one element, convert them to the other.
				if (player.getElement () == element.electricity) { 
					player.changeElement (element.ice);
					changeAnimation.SetTrigger ("Breed");
				} else {
					player.changeElement (element.electricity);
					changeAnimation.SetTrigger ("Breed");
				}
				messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
			}else
				messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}

	public IEnumerator checkAnswer4(){
		
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
		
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		
		string answer = input4.GetComponent<InputField>().text;

		if (string.IsNullOrEmpty (answer)) 
			answer = "0";

		if (answer == "50%")
			answer = "50";

		int ansNum;
		
		if (int.TryParse(answer, out ansNum)) {
			if (ansNum ==50){
				
				gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000);
				
				messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3));
				yield return new WaitForSeconds (.5f);
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7);
				
				// If the player is one element, convert them to the other.
				if (player.getElement () == element.electricity) { 
					player.changeElement (element.ice);
					changeAnimation.SetTrigger ("Breed");
				} else {
					player.changeElement (element.electricity);
					changeAnimation.SetTrigger ("Breed");
				}
				messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
			}else
				messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}

	public IEnumerator checkAnswer5(){
		
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
		
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		
		string answer = input5.GetComponent<InputField>().text;
		
		if (string.IsNullOrEmpty (answer)) 
			answer = "0";
		
		float ansNum;
		
		if (float.TryParse(answer, out ansNum)) {
			if (ansNum ==.50){
				
				gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000);
				
				messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3));
				yield return new WaitForSeconds (.5f);
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7);
				
				// If the player is one element, convert them to the other.
				if (player.getElement () == element.electricity) { 
					player.changeElement (element.ice);
					changeAnimation.SetTrigger ("Breed");
				} else {
					player.changeElement (element.electricity);
					changeAnimation.SetTrigger ("Breed");
				}
				messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
			}else
				messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}

	public IEnumerator checkAnswer6(){
		
		Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
		Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
		
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		
		string answer = input6.GetComponent<InputField>().text;
		
		if (string.IsNullOrEmpty (answer)) 
			answer = "0";
		
		float ansNum;
		
		if (float.TryParse(answer, out ansNum)) {
			if (ansNum ==.25){
				
				gameObject.transform.localPosition = new Vector3 (-1000, -1000, -1000);
				
				messageHandler.StartCoroutine (messageHandler.showMessage ("Time Storm", 3));
				yield return new WaitForSeconds (.5f);
				Instantiate (timeStormCluster, new Vector3 (-0.05f, 0.16f, 30.97f), Quaternion.identity);
				yield return new WaitForSeconds (7);
				
				// If the player is one element, convert them to the other.
				if (player.getElement () == element.electricity) { 
					player.changeElement (element.ice);
					changeAnimation.SetTrigger ("Breed");
				} else {
					player.changeElement (element.electricity);
					changeAnimation.SetTrigger ("Breed");
				}
				messageHandler.StartCoroutine (messageHandler.showMessage ("Breeding success!", "Phenotype has been changed!", 2, 3));
			}else
				messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		} else
			messageHandler.StartCoroutine (messageHandler.showMessage ("Oops.  Something went wrong.", "You must not have gotten that right.", 2, 3));
		Destroy (this.gameObject);
	}
}
