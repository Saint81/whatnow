using UnityEngine;
using System.Collections;

public class Adlib{
	private string[] found = new string[11] {"discovered", "dug up", "exposed", "found", "revealed", "unconcealed", "uncovered", "unearthed", "unmasked", "unsurfaced", "unveiled"};
	private string[] smells = new string[13] {"decomposing flesh", "dried blood", "burnt furniture", "dried vomit", "raw sewage", "a dead skunk", "a gas leak", "burnt hair", "fresh urine", "dirty underwear", "rotting teeth", "mayonnaise", "stagnant water"};

	private string[] house_rooms = new string[10] {"the backyard", "the basement", "the bedroom", "the dining room", "the garbage", "the kitchen", "the living room", "within the walls", "the floorboards", "the ceiling"};
	private string[] house_sounds = new string[7] {"scratching", "growling", "soft sobbing", "yelling", "maniacal laughter", "a shrill cry", "mumbling"};

	private string[] car_locations = new string[9] {"under the passenger seat", "in the trunk", "under the hood", "under the driver seat", "in the glove box", "under the car", "in the engine", "in the gas tank", "in the roof"};
	private string[] car_sounds = new string[7] {"a ticking noise", "scratching", "static noise", "a dial tone", "tapping", "a click", "a siren"};

	private string[] explosives = new string[7] {"explosive mouse trap", "tripwire", "claymore", "C4 charge", "IED", "shotgun trap", "explosive bear trap"};
	private string[] explode = new string[4] {"trigger", "activate", "detonate", "discharge"};

	private string[] weapons = new string[6] {"machine gun", "tommy gun", "laser gun", "revolver", "crossbow", "machete"};
	private string[] health = new string[5] {"medkit", "syrringe of morphine", "bottle of painkillers", "tiny Band-Aid", "gauze pad"};
	private string[] food = new string[7] {"banana", "pineapple", "can of Sprite", "roasted turkey", "can of beans", "bottle of water", "questionably prepared Fugu fish"};
	private string[] tools = new string[5] {"Monkey wrench", "drill", "screwdriver", "can of gasoline", "box of screws"};

	private string[] body_parts = new string[13] {"arm", "leg", "back", "butt", "face", "neck", "ankle", "shoulder", "stomach", "chest", "groin", "hand", "foot"};
	private string[] pain = new string[10] {"bruised", "bleeding", "shattered", "scraped", "gored", "cut", "broken", "in severe pain", "starting to fall off", "melted"};

	public string Search(string item = null){
		if(item != null){
			if(item == "weapon")
				return "You " + found[(int)(Random.value * found.Length)] + " a " + weapons[Random.Range(0, weapons.Length)] + " and added it to your collection of armaments";
			else if(item == "health")
				return "You " + found[(int)(Random.value * found.Length)] + " a " + health[Random.Range(0, health.Length)] + " and you patch yourself up";
			else if(item == "tool")
				return "You " + found[(int)(Random.value * found.Length)] + " a useful tool, a " + tools[Random.Range(0, tools.Length)];
			else if(item == "food")
				return "You " + found[(int)(Random.value * found.Length)] + " and consumed a " + food[Random.Range(0, food.Length)];
			else 
				return "You accidentaly " + explode[(int)(Random.value * explode.Length)] + " a " + explosives[Random.Range(0, explosives.Length)] + "! Your " + body_parts[Random.Range(0, body_parts.Length)] + " is now " + pain[Random.Range(0, pain.Length)];
		}
		else
			return "You " + found[(int)(Random.value * found.Length)] + " nothing...";
	}
	
	public string ColorHouse(){
		if(Random.value > 0.5f)
			return "You hear " + house_sounds[Random.Range(0, house_sounds.Length)] + " coming from " + house_rooms[Random.Range(0, house_rooms.Length)];
		else
			return "You smell " + smells[(int)(Random.value * smells.Length)] + " wafting from " + house_rooms[(int)(Random.value * house_rooms.Length)];
	}

	public string ColorCar(){
		if(Random.value > 0.5f)
			return "You hear " + car_sounds[(int)(Random.value * car_sounds.Length)] + " coming from " + car_locations[(int)(Random.value * car_locations.Length)];
		else
			return "You smell " + smells[(int)(Random.value * smells.Length)] + " wafting from " + car_locations[(int)(Random.value * car_locations.Length)];
	}
}
