using System.ComponentModel.DataAnnotations;
using System;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab4a();
        Creature c = new Elf("Elandor", 5, 3);
        Console.WriteLine(c);
        Lab4b();
        Lab5a();
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
        };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
    static void Lab5a()
    {
        Console.WriteLine("Creating a rectangle:");
        try
        {
            Rectangle rect1 = new Rectangle(3, 1, 10, 5);
            Console.WriteLine($"Rectangle created: {rect1}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        Console.WriteLine("\nCreating rectangle with switched points");
        try
        {
            Rectangle rect4 = new Rectangle(10, 5, 3, 1);
            Console.WriteLine($"Rectangle created: {rect4}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        Console.WriteLine("\nCreating a rectangle with points:");
        try
        {
            Point p1 = new Point(8, 2);
            Point p2 = new Point(3, 6);
            Rectangle rect2 = new Rectangle(p1, p2);
            Console.WriteLine($"Rectangle created: {rect2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\nAttempt to create an invalid rectangle:");
        try
        {           
            Rectangle invalidRect = new Rectangle(4, 4, 4, 8);
            Console.WriteLine($"Rectangle created: {invalidRect}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\nChecking if points are contained within the rectangle:");
        Rectangle rect3 = new Rectangle(2, 2, 7, 7);
        Point insidePoint = new Point(4, 4);
        Point outsidePoint = new Point(8, 8);

        Console.WriteLine($"Rectangle: {rect3}");
        Console.WriteLine($"Does the rectangle contain the point {insidePoint}? {rect3.Contains(insidePoint)}");
        Console.WriteLine($"Does the rectangle contain the point {outsidePoint}? {rect3.Contains(outsidePoint)}");
    }
}
        
