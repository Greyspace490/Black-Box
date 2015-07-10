using UnityEngine;
using System.Collections;

// EventManager takes info sent from nodes and determines what should happen. Used on the Overworld maps.
// Numbers correspond to node numbers.
//

public class EventManager : SupraEvent {
	
	public DialogueHandler dh;
	
	public override void playEvent(int i){

		if (i == 1) { // Start of Game / Lincoln Park Zoo
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What? Where... where am I? It's the Lincoln Park Zoo but... everything is destroyed. And... old.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "How did I even end up with this? Did those... soldiers attack me for it?", "???", Portrait.QuinnF, "Hello World.", @"Settings/amulet&lab"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "!!!", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Did... did you just say something??", "???", Portrait.QuinnF, "A salutation.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Am I talking to a parking meter right now?", "???", Portrait.QuinnF, "Affirmative.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "And is this not the weirdest thing ever?", "???", Portrait.QuinnF, "Strangeness is relative. You are human, yes?", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I'm Kayla.", "???", Portrait.QuinnF, "And I am Serial Model Qhynp5LL.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessageBottom("Serial Model Qhynp5LL", Portrait.QuinnF, "But if you value continued existence, I recommend our swift departure.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "You want us to leave?", "Serial Model Qhynp5LL ", Portrait.QuinnF, "Yes. Now. You mentioned soldiers. They may be afoot.", @"Settings/LincolnPark"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Good point, Quinn. Can I please call you Quinn? Your name is a lot.", "Quinn", Portrait.QuinnF, "A nickname? What is this I'm feeling. Is it... Love?", @"Settings/LincolnPark"));
		}

		if (i == 3) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Is that Navy Pier? What happened to it?", "Quinn", Portrait.QuinnF, "Hypothesis: Catastrophic devastation."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "My mom used to take me there for music festivals when I did well in school.", "Quinn", Portrait.QuinnF, "Nice."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "I wonder if the Art Institute is okay. All those paintings..."));
		}

		if (i == 5) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "It looks like Chicago but... this can't be my world."));
		}

		if (i == 6) { // Navy Pier
			Chibi chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
			Save save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
			save.setPreviousLocation(chibi.transform.localPosition);
			Application.LoadLevel(6);
		}

		if (i == 7) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "We can't run forever. You're from around here, right? Where should we hide?", "Quinn", Portrait.QuinnF, "Error. I have no recollection prior to meeting you."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "You've got to be kidding me.", "Quinn", Portrait.QuinnF, "I do, however, have encyclopedic knowledge of subjects including mathematics, physics, and biology."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Hmm... "));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Hey. Is that Soldier Field?"));
		}

		if (i ==9){
			StartCoroutine(dh.showMessage("???", Portrait.Calvert, "AHHH!"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Ahh!"));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Ah."));
			StartCoroutine(dh.showMessage("???", Portrait.Calvert, "I'm just a shepherd. I don't want any trouble. "));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Us either. Are you okay? You seem kind of jumpy.", "???", Portrait.CalvertF, "Is... Is that a Widdershin??"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "A what?", "???", Portrait.CalvertF, "You have an amulet.", @"Settings/amulet"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Yeah. Everyone is obsessed with it, whatever it is.", "???", Portrait.CalvertF, "You're clearly not from around here. That amulet protects every nearby person from time storms.", @"Settings/amulet"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Time Storms?", "???", Portrait.CalvertF, "They're part of the aftermath of the war. When a storm hits, time gets away from you. As in suddenly 10000 years have passed and you're dead."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Oh.", "???", Portrait.CalvertF, "Please, please, please! You’ve got to save me. You can protect me from the time storms! I need to get back to my flock."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "We do not even know you."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Quinn!", "???", Portrait.CalvertF, "I am Calvert, a lowly shepherd."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "This is Quinn. I'm Kayla. By the way: are you...", "Calvert", Portrait.CalvertF, "Yes, yes. I'm an elf. You're a human. Let's not make a big deal of it."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Seriously? No no, we are definitely talking about it—"));
			StartCoroutine(dh.showMessage("???", Portrait.Jay, "Bah."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Ohmygosh! Is that one of your sheep? He's adorable!", "Quinn", Portrait.QuinnF, "I've seen more adorable."));
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "Jay? Yes. He's my best and brightest. Ran off from the flock and I've been chasing him for days now."));
			StartCoroutine(dh.showMessage("Jay", Portrait.Jay, "Bah.", "Quinn", Portrait.QuinnF, "He appears to have taken a liking to you, Kayla."));
			StartCoroutine(dh.showMessage("Jay", Portrait.Jay, "Bah.", "Kayla", Portrait.KaylaF, "Bah."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Bah.", "Jay", Portrait.JayF, "Bah."));
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "Strange. Remember: he's mine."));
		}

		if (i ==10){
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What's with the fences?", "Calvert", Portrait.CalvertF, "What few animals remain in our world are dangerous. The fields are overtaken by snakes."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Can't they just slither through the chain links?"));
		}

		if (i == 11) {
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "That was incredible!  Jay and the other sheep actually listened to you!", "Kayla", Portrait.KaylaF, "Did you see the size of that snake?!?"));
		}

		if (i ==12){
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "So there's the stadium. But what's that ahead?", "Calvert", Portrait.CalvertF, "A lab. Looks like it's from before the 6th Imperial War."));
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "When the environment started dying, elves became suddenly interested in biology. Turns out that mass extinction affects us all."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "I suggest we attend to the lab. The ecosystem of this world is damaged. Animals are dying. Perhaps there are clues there.", "Calvert", Portrait.CalvertF, "Yes! I agree. The stadium looks dangerous. Let's avoid that."));
		}

		if (i ==13){ // Soldier Field
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "I'm going to stay back here. Jay seems afraid, doesn't he?", "Jay", Portrait.JayF, "Bah."));
			StartCoroutine(dh.showMessage("Commander", Portrait.Simab, "This is a colossal disaster. We started the mission with a widdershin. Now we must hide like knaves from time storms."));
			StartCoroutine(dh.showMessage("Commander", Portrait.Simab, "And to make matters worse, we have lost the Black Box as well.", "Soldier", Portrait.CorderoF, "Plus there were three of us."));
			StartCoroutine(dh.showMessage("Commander", Portrait.Simab, "Now we have neither the Black Box nor an amulet.", "Soldier", Portrait.CorderoF, "Commander Simab: There were also three of us. We lost Ada."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Oh. Yes. Ada."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Anyway."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "We need to comb the area. That human girl may know something.", "Soldier", Portrait.CorderoF, "Sir? Shouldn't we return to Locus? We've completed the mission. We have what we were sent for."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "We are not returning, Cordero, until we are whole again. The Black Box, an amulet, and this pigeon we have retrieved from Earth."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "We return with everything, or we return with nothing. That's an order, soldier.", "Cordero", Portrait.CorderoF, "Sir, permission to speak."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Denied. I am tired of thinking.  Soldier, give me an official reason we could not leave this area.", "Cordero", Portrait.CorderoF, "Sir?  We… cannot leave this cordon until we tap into this pigeon’s power?"));
			StartCoroutine(dh.showMessageBottom("Cordero", Portrait.CorderoF, "And currently, we cannot defeat the sheep blocking the exit, nor the snakes beyond them in the field?"));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Perfect.", "Cordero", Portrait.CorderoF, "And Ada?"));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "As I said. The Black box, an amulet, and the pigeon.", "Cordero", Portrait.CorderoF, "Sir… yes sir. For the Imperial Army!"));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "::Sigh:: Yes. To the Imperium."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "We should go."));
		}

		if (i ==14){ // Lab
			Chibi chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
			Save save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
			save.setPreviousLocation(chibi.transform.localPosition);
			Application.LoadLevel(5);
		}

		if (i ==15){
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "Just up ahead! We're almost there!"));
		}

		if (i ==16){ // Boss battle
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "We're back! I never thought we'd make it alive! So we’ll just rejoin the flock… Jay? Jay!", "Jay", Portrait.JayF, "Bah."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "It is patently obvious that he prefers Kayla's companionship.")); 
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "The human girl! And the defector!", "Calvert", Portrait.CalvertF, "No! You've mistaken me for someone else. Please!"));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Blast them, pigeon!"));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "This pigeon is worthless. Human, you have obvious control over those Battle Sheep. "));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "Explain how to make this pigeon fire lasers, or create tidal waves, or reverse gravity.", "Kayla", Portrait.KaylaF, "That's the pigeon you took from outside the zoo! Leave him alone, he's just a regular pigeon."));
			StartCoroutine(dh.showMessage("Commander Simab", Portrait.Simab, "I cannot face this herd without backup. Remain here. Cordero! I need backup."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "Curious. He appears to be leaving."));  
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Did he say... Battle Sheep?", "Calvert", Portrait.CalvertF, "They shoot lightning."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Of course they do."));
			StartCoroutine(dh.showMessage("Quinn", Portrait.Quinn, "He called you a defector.", "Calvert", Portrait.CalvertF, "I don’t know what he’s talking about."));
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "Look, I know a place where you can stay. It's through the fields, at the windmills."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Stay??", "Calvert", Portrait.CalvertF, "Like it or not, you seem to be in it for the long haul."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Well, we need to get out of here before that Simab guy gets back with backup.", "Calvert", Portrait.CalvertF, "The only problem is that these fields are filled with snakes. But we don't have much of an option at this point."));
			StartCoroutine(dh.showMessageBottom("Quinn", Portrait.QuinnF, "Through the fields, then. Kayla, you can command the herd to protect us."));
		}

		if (i ==18){
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "That was a close one.", "Quinn", Portrait.QuinnF, "Kayla, you are more than capable. These snakes are nothing to your intellectual might."));
		}

		if (i ==19){
			Application.LoadLevel(8);
		}

		if (i ==26){
			StartCoroutine(dh.showMessage("Calvert", Portrait.Calvert, "We're never going to make it!  We should have stayed back in the city.", "Quinn", Portrait.QuinnF, "Kayla has this handled.  Please remain quiet."));
		}

		if (i ==27){
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "We're... we're almost there!"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Never question the power of the sheep.", "Quinn", Portrait.QuinnF, "I believe, after this, I may even dream electric sheep."));
			StartCoroutine(dh.showMessageBottom("Calvert", Portrait.CalvertF, "Kayla, I have something to tell you."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Is everything okay?", "Calvert", Portrait.CalvertF, "I'll explain myself—and the rest of us—when we reach the windmills."));
		}
	}
}
