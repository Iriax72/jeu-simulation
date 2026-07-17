using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class Game
{
    // Ressources & batiments
    private static int wood;
    private static int farms;
    private static int meal;
    private static bool hasCityhall;

    public static void Init ()
    {
        wood = 0;
        farms = 0;
        meal = 0;
        hasCityhall = false;
    }
    public static string GetState()
    {
        object state = new
        {
            wood = wood,
            meal = meal,
            farms = farms,
            hasCityhall = hasCityhall
        };
        string serializedState = JsonSerializer.Serialize(state);
        return serializedState;
    }

    // Fonctions ressources & batiments
    public static void GetRessources()
    {
        wood ++;
        meal += farms;
    }

    public static string Createfarms()
    {
        if (wood < 8)
        {
            return JsonSerialize.Serialize();
        }
        wood -= 8;
        farms += 1;
        return JsonSerializer.Serialize(new string[] { "true" });
    }

    public static string CreateCityhall()
    {
        if (hasCityhall || wood < 10 || meal < 80)
        {
            return JsonSerializer.Serialize(new string[] { "false" });
        }
        wood -= 10;
        meal -= 80;
        hasCityhall = true;
        return JsonSerializer.Serialize(new string[] { "true" });
    }
}
