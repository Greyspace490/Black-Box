using UnityEngine;
using System.Collections;

// EventManagerInnerLab takes info sent from nodes and determines what should happen. 
// Handles the lab, linked from the first Overworld.
//

public class EventManagerInnerLab : SupraEvent {

	public DialogueHandler dh;
	
	public override void playEvent(int i){
		
		if (i == 61) {
			Chibi chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
			Save save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
			save.setNewLocation(save.getPreviousLocation());
			save.setPreviousLocation(chibi.transform.localPosition);
			Application.LoadLevel(4);
		}

		if (i == 62) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What happened here?", "Quinn", Portrait.QuinnF, "Unclear. Allow me to view the documentation..."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "..."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Quinn?", "Quinn", Portrait.QuinnF, "Apologies. A scientist left a mystery novel. The Hardy Elves and the Pillars of Horded Wealth. Fascinating."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Anyway... Some kind of disaster befell this world. They were attempting to save the environment, starting with the animals."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Calvert: Is that right? What exactly happened to this world?", "Calvert", Portrait.CalvertF, "So there was at least a couple of wars that lead to all the Court Dragoons coming together and...  look, we can talk about this after I get to my sheep."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "It is clear that they were exploring the field of genetics. But it seems this lab had only just discovered the Hardy-Weinberg equation."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Hardy-Weinberg? Sounds familiar...", "Quinn", Portrait.QuinnF, "The Hardy-Weinberg Equation is used in studying whole populations of organisms."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Why? I mean, it doesn't look like it helped them solve anything.", "Quinn", Portrait.QuinnF, "It is a tool that is useful in understanding the process of evolution. Specifically, it is used to calculate two important things:"));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "First, the frequency of different alleles. An allele is one of two versions of a gene.  Either an allele is dominant (A) or recessive (a)."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "So the Hardy-Weinberg equation can help you calculate, in a population, how many organisms have those dominant or recessive genes."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "And second, the equation can be used to calculate the frequency of different genotypes."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "A genotype is a combination of dominant and recessive alleles."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "So homozygous dominant is one combination (AA), homozygous recessive is another (aa), and heterozygous is the last (Aa)."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Okay, so maybe they were trying to breed animals that could survive in this world. It's pretty harsh out there.", "Quinn", Portrait.QuinnF, "It is possible."));
		}
	
		if (i == 63) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I can see equations written everywhere.  They were obsessive. But it wasn't enough to save the animals?", "Quinn", Portrait.QuinnF, "The equation is useful. It helps us understand real world situations."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "But…?", "Quinn", Portrait.QuinnF, "But an important thing to know is that the Hardy-Weinberg equation applies only to populations in equilibrium."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What does it mean for a population to be in equilibrium?", "Quinn", Portrait.QuinnF, "If a population is in equilibrium, it isn’t evolving, and thus its gene pool frequency will be stable."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "We can calculate genotype and allele frequency using the Hardy-Weinberg equation because they remain constant and won’t change."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "But some conditions have to be met in order for a population to be at equilibrium."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Like what?", "Quinn", Portrait.QuinnF, "There are several. Remember, a population at equilibrium is one where evolution is not occurring."));							
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "So basically all the things that contribute to evolution need to be absent.", "Quinn", Portrait.QuinnF, "Exactly. A population meets the criteria for equilibrium if it has these five things:"));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "First, the sample must be a large population size."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Second, there must be an absence of migration."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Third, there must be no net mutations. Mutation must be at a minimum."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Fourth, mating must be random."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "And fifth, there must be an absence of selection. No human interference, as they have done with domesticated plants and animals."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "It seems like you would need a very controlled environment for all that to happen.", "Quinn", Portrait.QuinnF, "Affirmative. In the real world, equilibrium is difficult to achieve. But in a lab, we can control for much more."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Even if they figured everything out, it was just in this lab. They never got a chance to test it in the real world."));
		}

		if (i == 64) {

			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "An aquarium... labeled \np² + 2pq + q² = 1", "Quinn", Portrait.QuinnF, "The Hardy-Weinberg equation. They appear to have been studying the physical traits of fish."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "They were studying their phenotypes?  And... all this glass is scorched.", "Calvert", Portrait.CalvertF, "Classic firefish.  Wait.  You mean you don't have firefish from where you're from??"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Could fish have really done this?  The animals of this world are so weird."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Let's figure out what they were doing. So how does the Hardy-Weinberg equation work?", "Quinn", Portrait.QuinnF, "As you mentioned, the equation is as follows: p² + 2pq + q² = 1"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Where p² represents the frequency of homozygous dominant individuals.", "Kayla", Portrait.KaylaF, "Homozygous dominant is AA. Organisms with two dominant alleles."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "2pq represents frequency of heterozygous individuals.", "Kayla", Portrait.KaylaF, "Heterozygous meaning Aa.  Since they also have at least one dominant allele, they would express that allele's physical traits.  Its phenotype."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "And finally q² represents the frequency of homozygous recessive individuals.", "Kayla", Portrait.KaylaF, "Organisms with two recessive alleles: aa. With no dominant alleles, the recessive phenotype, like—blue eyes—would finally show."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Each part of the p² + 2pq + q² equation expresses the percent of that genotype that exists in the population.", "Kayla", Portrait.KaylaF, "So that's why they all add up to 1. Because 1 is the same as 100 percent."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Correct. It also means that we can calculate populations from portions of data using the equation."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Assume, for example, that shooting fire is a dominant trait for firefish..."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Since it is a dominant trait, fish with genotypes of either Aa and AA will express fire phenotypes."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "So if fish with genotype AA = .49...", "Kayla", Portrait.KaylaF, "Or 49 percent of the population..."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "And fish with genotype Aa = .42...", "Kayla", Portrait.KaylaF, "Or 42 percent of the population."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "The percentage of the population that does not express the fire phenotype...", "Kayla", Portrait.KaylaF, "Is...  .09 or 9%.  Because .49 + .42 is .91.  If we subtract that from 1, which represents 100% of the total population, we get .09!"));
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "I'm lost.", "Kayla", Portrait.KaylaF, "We all get lost sometimes, Calvert. Practice makes perfect."));
		}

		if (i == 65) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "A notebook.  It's signed '-A'", "Quinn", Portrait.QuinnF, "Allow me to parse this document."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "It is the journal of a scientist. It has two parts, one that I understand and one that I do not. I will explain the part I understand."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "This scientist got further than any of the others at understanding the Hardy-Weinberg equation. Besides genotype frequency—", "Kayla", Portrait.KaylaF, "—the frequency of AA, Aa, and AA in a population—"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "—they also were using the equation to study the total frequency of dominant and recessive alleles in the population.", "Calvert", Portrait.CalvertF, "Wait.  What's the difference?"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Look at the equation p² + 2pq + q²: heterozygous organisms (2pq) may only show dominant traits even though they have a recessive allele.", "Kayla", Portrait.KaylaF, "To see how many organisms have a recessive gene (a), you have to count the percent that are aa AND those that are Aa."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Yes. To do that, we can begin by factoring p² + 2pq + q², which gives us (p + q)(p + q). This can also be expressed as (p+q)²", "Kayla", Portrait.KaylaF, "So if (p+q)² = 1, you can find the square root of both sides and get p+q = 1."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "The amount of organisms with at least one recessive allele plus the amount of animals with at least one dominant allele is equal to 1.", "Kayla", Portrait.KaylaF, "Which is the same as 100% of the population. That makes sense."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Take for example, a population of rats.", "Calvert", Portrait.CalvertF, "Rats?  Gross.  Why not sheep?  Can it be sheep?"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Let's say that a rat being large results from a homozygous recessive genotype.", "Kayla", Portrait.KaylaF, "So only rats with two recessive alleles are large. That's what q² represents."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "And let's say that there are 120 small rats and 40 small ones in a population."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "The only way for a recessive phenotype to show itself is for an organism to have two recessive alleles. To be homozygous recessive.", "Kayla", Portrait.KaylaF, "So 40 large rats are homozygous recessive."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "So what percentage of the population of the 160 total rats do the 40 large rats represent?", "Kayla", Portrait.KaylaF, "If there are 160 rats total, 40 divided by that is .25 or 25%"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "If 0.25 is the frequency of homozygous recessive individuals in the population, what variable in the Hardy-Weinberg equation represents this number?", "Kayla", Portrait.KaylaF, "Well... q² represents the frequency of homozygous recessive rats. So q² = .25"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "If q² = .25, we are able to calculate for q by finding the square root of both sides of the equation.", "Kayla", Portrait.KaylaF, "The square root of .25 is .5, so p = .5"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Since we know p + q = 1, and we know p, we can calculate for q.", "Kayla", Portrait.KaylaF, "It would be 1 - p.  Since p is .5, that means the answer is 1 -.5, which equals .5"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "That is the extent of the research expressed in this journal."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Wait."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "You said there was something about the journal you didn't understand.", "Quinn", Portrait.QuinnF, "This scientist. She wasn't just interested in the Hardy-Weinberg equation.")); 
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "She was also experimenting with ways to control the animals. To make what sounds like an army."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "How did she control the animals?", "Quinn", Portrait.QuinnF, "It was unclear."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Wait, did you say it was a she?  When did you find out A was a she?", "Quinn", Portrait.QuinnF, "...I don't know that she's a woman. It was unclear."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Oh.  Okay..."));
		}

		if (i == 66) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What is this? This handwriting looks familiar.", "Quinn", Portrait.QuinnF, "These pages are signed '-A.' Part of it, at least, appears to be the final part of the Hardy-Weinberg equation."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Well, let's dive in."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Diving commencing."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "p² + 2pq + q² = 1, which can be broken down to (p +q)² = 1", "Kayla", Portrait.KaylaF, "And if we find the square root for both sides, that can be broken down to \np+q = 1 "));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Right.  Let's say that we are examining a population of rats, and that the recessive allele leads to larger-than-average rats."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Let's say that we know that p is equal to .5 and q is equal to .5"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "The question these papers pose: Can we use this information to calculate how many of the rats are heterozygous carriers of the recessive allele?", "Kayla", Portrait.KaylaF, "You mean rats that carry a recessive allele, but since they don't have two of that allele, don't show the phenotype of being large?"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Yes. We can solve for this. We know now that p = 0.5 and q = 0.5. What, then, is 2pq?", "Kayla", Portrait.KaylaF, "If p = 0.5 and q = 0.5, then 2pq = 0.5"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Correct, .5 or 50% of the total population of rats is heterozygous and despite being small, carries the recessive allele."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Another question: If we have a total of 160 rats, what pecentage of them are heterozygous?", "Kayla", Portrait.KaylaF, "Well... If 2pq = 0.5 and the total population contains 160 rats, then 80 rats are heterozygous, because 80 is 160 times .5"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Knowing that p = .5 and q is = .5, we can also determine the rest of \np² + 2pq + q²", "Kayla", Portrait.KaylaF, "Well, .5 times itself is .25, so p² = .25 and q² = .25"));
			StartCoroutine(dh.showMessageBottom("Kayla", Portrait.KaylaF, ".25 + .5 + .25 = 1 and p² + 2pq + q² = 1.  Everything checks out!"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "So now you can see how knowing just a couple of pieces of information allowed us to calculate genotype and allele frequency in my imaginary lab rats."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Got it.  I think. Do the pages of this journal explain any of what's going on with all the animals around here?", "Quinn", Portrait.QuinnF, "They mention possible experiments intended to make snakes resistant to lightning storms."));
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "Lightning storms??  There haven't been lightning storms in this city for hundreds of years.  How old is this lab?", "Quinn", Portrait.QuinnF, "Unclear.  It also seems unusually small when compared to the size of the building as seen from the outside."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Anything about the author of the writings?  Of -A?", "Quinn", Portrait.QuinnF, "No."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Quinn?  Are you sure?", "Quinn", Portrait.QuinnF, "We should go."));
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "Quinn is right.  We should get out of here."));
		}
	}
}