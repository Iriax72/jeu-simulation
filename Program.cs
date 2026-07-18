public static class Game
{
    // Ressources
    public static int Wood { get; private set; }
    public static int Meal { get; private set; }
    public static int Farms { get; private set; }
    public static bool HasCityhall { get; private set; }

    // Initialisation
    public static void Main()
    {
        Wood = 0;
        Meal = 0;
        Farms = 0;
        HasCityhall = false;
    }

    // Fonctions de jeu
    public static void GetRessources()
    {
        Wood++;
        Meal += Farms;
    }

    public static bool CreateFarm()
    {
        if (Wood < 8)
        {
            return false;
        }
        Wood -= 8;
        Farms += 1;
        return true;
    }

    public static bool CreateCityhall()
    {
        if (HasCityhall || Wood < 10 || Meal < 80) 
        {
            return false;
        }
        Wood -= 10;
        Meal -= 80;
        HasCityhall = true;
        return true;
    }
}