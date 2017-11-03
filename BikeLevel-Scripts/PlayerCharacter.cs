
public class PlayerCharacter {

	//variables that carry over to the next level
	private static int kills, deaths, collected;

	public static int Kills 
	{
		get 
		{
			return kills;
		}
		set 
		{
			kills = value;
		}
	}

	public static int Deaths 
	{
		get 
		{
			return deaths;
		}
		set 
		{
			deaths = value;
		}
	}

	public static int Collected 
	{
		get 
		{
			return collected;
		}
		set 
		{
			collected = value;
		}
	}
		
}
