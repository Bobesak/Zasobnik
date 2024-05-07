global using Spectre.Console;
using System;
using System.Threading;
using gun;

namespace GunHandling;

    public class Program
    {
        static void Main(string[] args)
        {
            Gun weapon = new() { };
            Console.Clear();
            weapon.Fire();
            Console.ReadKey();
        }
    }

