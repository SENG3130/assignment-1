﻿// File Name:   InteractiveLayered.cs
// Developer:   Jordan Cork
//
// Description: Implements a stardard 3-tier layered build of an interactive KWIC indexing system..
//
// Notes:       


namespace CDT.InteractiveKWIC
{
    class InteractiveLayered
    {
        static void Main(string[] args)
        {
            InteractiveLayer interLayer = new InteractiveLayer();
            interLayer.run(); // Begins the interactive application
        }
    }
}