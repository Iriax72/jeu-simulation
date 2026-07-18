using System;
using System.Text.Json;
using Microsoft.JSInterop;

public static class Game
{
    public static void Main()
    {

    }

    // Ressources
    public static int Wood { get; private set; }
    public static int Meal { get; private set; }
    public static int Farms { get; private set; }
    public static bool HasCityhall { get; private set; }

    [JSInvokable]
    public static string GetState()
    {
        object state = new {
            wood = Wood,
            meal = Meal,
            farms = Farms,
            hasCityhall = HasCityhall
        };
        return JsonSerializer.Serialize(state);
    }

    // Initialisation
    [JSInvokable]
    public static void Init()
    {
        Wood = 0;
        Meal = 0;
        Farms = 0;
        HasCityhall = false;
    }

    // Fonctions de jeu
    [JSInvokable]
    public static void GetRessources()
    {
        Wood++;
        Meal += Farms;
    }

    [JSInvokable]
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

    [JSInvokable]
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