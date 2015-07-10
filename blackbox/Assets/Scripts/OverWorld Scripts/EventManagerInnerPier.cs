using UnityEngine;
using System.Collections;

// EventManagerInnerPier takes info sent from nodes and determines what should happen. 
// Handles the pier, linked from the first Overworld.
//

public class EventManagerInnerPier : SupraEvent {
	
	public DialogueHandler dh;
	
	public override void playEvent(int i){
		
		if (i == 31) {
			Chibi chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
			Save save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
			save.setNewLocation(save.getPreviousLocation());
			save.setPreviousLocation(chibi.transform.localPosition);
			Application.LoadLevel(4);
		}

		if (i == 32) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "No sign of life anywhere.", "Quinn", Portrait.QuinnF, "False. You mean no signs of human life. Fish populate this area."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "If you want to call them fish. They're puny.", "Quinn", Portrait.QuinnF, "According to Darwin, there is constant competition between lifeforms for resources.")); 
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "This competition results in certain individuals surviving to pass desirable genetic traits on to their children."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "It is likely the phenotype of these fish have helped them survive."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Phenotype?", "Quinn", Portrait.QuinnF, "A phenotype consists of the traits we can observe. These traits arise from your genotype. Your genes."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Human genes allow for blonde as a phenotype.  Your hair's phenotype, for example, is brown."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "So these fish are small for a reason.", "Quinn", Portrait.QuinnF, "Lifeforms that are successful at reproducing have superior evolutionary fitness."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "It's weird to think that being smaller would be adaptive. "));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "But I guess in an environment where there isn't much food, having a smaller appetite has its advantages."));
		}

		if (i == 33) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "This water is cut off from the ocean.  And there are hardly any fish left here.", "Quinn", Portrait.QuinnF, "Possible explanation: genetic variation is important for a population's evolutionary survival."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "For time untold, these fish have been cut off from the larger population."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "They may have fewer gene variants to work with. If the environment changes, it will likely wipe them out."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "How sad."));
		}

		if (i == 34){
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I won a goldfish at a fair once.  It came in a little bag.  It died before I got home.", "Quinn", Portrait.QuinnF, "Error in processing: I do not understand the point of your depressing anecdote."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "The environment affects these fish, right?", "Quinn", Portrait.QuinnF, "Yes.  Though it takes thousands of years, and generations, for populations of organisms to evolve."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Of note: a stable or chaotic environment has different effects on the evolutionary rate and the direction of a population."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Meaning these fish are going to evolve at a different rate because their lake never changes.", "Quinn", Portrait.QuinnF, "Indeed."));
		}

		if (i ==35){
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I did a report on pollution in Lake Michigan. It was nothing compared to this. But it looks so much like my lake... ", "Quinn", Portrait.QuinnF, "Are the fish familiar?"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Fish?  Oh!  I didn't even see them!  They're almost as dark as the water!", "Quinn", Portrait.QuinnF, "They seem to have adapted to the color of the lake."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "So...  Over time, the bright fish would get eaten by predators, and the ones that were darker were harder to find.", "Quinn", Portrait.QuinnF, "It would be a useful genetic variation, yes?"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I can't tell if that's actually a question."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "But, how can we know that's why they evolved this way?", "Quinn", Portrait.QuinnF, "We can't. I am just a parking meter."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Fossil records would help, as well as genetic tests.  Chance and random events can lead to evolutionary change as well, after all."));
		}

		if (i == 36) {
			StartCoroutine (dh.showMessageBottom ("Quinn", Portrait.QuinnF, "These fish are fascinating. I suspect they have one allele for big fins and one for small fins."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "An allele... That's a verion of a gene. You have two for each gene. One from each parent.", "Quinn", Portrait.QuinnF, "Someone was paying attention in school."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "Always."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "We are... were... on this chapter before I visited the zoo and ended up here."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "I remember... Dominant alleles were ones represented by a big A and recessive were repersented by a little a.", "Quinn", Portrait.QuinnF, "Now you're just showing off."));
			StartCoroutine (dh.showMessageBottom ("Quinn", Portrait.QuinnF, "As you'll recall, there are three combinations of alleles in a gene.  AA, Aa, and aa."));
			StartCoroutine (dh.showMessageBottom ("Quinn", Portrait.QuinnF, "If even one dominant allele is present, the traits it represents will show up in the organism."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "Yeah.", "Quinn", Portrait.QuinnF, "I am using that information to posit a guess about these fish."));
			StartCoroutine (dh.showMessageBottom ("Quinn", Portrait.QuinnF, "I suspect that so many of these fish have large fins that it is likely a dominant gene."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "How does that help us?", "Quinn", Portrait.QuinnF, "Reply hazy. Try again later."));
			StartCoroutine (dh.showMessage ("Kayla", Portrait.Kayla, "What?", "Quinn", Portrait.QuinnF, "...I don't know."));
		}

	}
}