﻿using AtlasWarriorsGame;
using DavyKager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenReaderApp
{
    /// <summary>
    /// Console version of Atlas Warriors, optimised for Screen Readers
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Tolk.TrySAPI(true);
            Tolk.Load();

            //Console.WriteLine("Querying for the active screen reader driver...");
            //string name = Tolk.DetectScreenReader();
            //if (name != null) {
            //  Console.WriteLine("The active screen reader driver is: {0}", name);
            //}
            //else {
            //  Console.WriteLine("None of the supported screen readers is running");
            //}

            //if (Tolk.HasSpeech()) {
            //  Console.WriteLine("This screen reader driver supports speech");
            //}
            //if (Tolk.HasBraille()) {
            //  Console.WriteLine("This screen reader driver supports braille");
            //}

            //Console.WriteLine("Let's output some text...");
            //if (!Tolk.Output("Hello, World!")) {
            //  Console.WriteLine("Failed to output text");
            //}

            //Console.WriteLine("Finalizing Tolk...");
            //Tolk.Unload();

            //Console.WriteLine("Done!");
            var g = new AtlasWarriorsGame.Game();
            DrawMap(g.CurrentDungeon);
            Console.ReadKey();
        }

        static void DrawMap(AtlasWarriorsGame.Dungeon Dungeon)
        {
            for (int iy = 0; iy < Dungeon.Height; ++iy)
            {
                Console.WriteLine();
                for (int ix = 0; ix < Dungeon.Width; ++ix)
                {
                    var tileChar = UiCommon.CellToScreen.CellScreenChar(
                        Dungeon.GetCell(new XY(ix, iy)));
                    Console.Write(tileChar);
                }
            }
        }
    }
}