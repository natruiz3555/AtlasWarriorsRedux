﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasWarriorsGame;
using static AtlasWarriorsGame.Dungeon;

namespace AtlasWarriorsGame.Tests
{
    /// <summary>
    /// Tests for the Dungeon class
    /// </summary>
    [TestFixture]
    public class DungeonTests
    {
        /// <summary>
        /// Initialise dungeons for test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Dungeon1 = new AtlasWarriorsGame.Dungeon(10, 10);
            Dungeon2 = new AtlasWarriorsGame.Dungeon(20, 10);
            Dungeon3 = new AtlasWarriorsGame.Dungeon(10, 20);
            Dungeon4 = new AtlasWarriorsGame.Dungeon(10, 10);
            Dungeon4.SetCell(new XY(2,2), DungeonCell.WALL);
            Dungeon4.SetCell(new XY(2,3), DungeonCell.CLOSED_DOOR);
            Dungeon4.SetCell(new XY(2,4), DungeonCell.OPEN_DOOR);
            Dungeon4.SetCell(new XY(2,5), DungeonCell.FLOOR);
        }

        /// 10x10 Dungeon, empty
        Dungeon Dungeon1;

        /// <summary>
        /// Locations that are out of bounds on Map 1
        /// </summary>
        static List<XY> Dungeon1OutOfBoundsData = new List<XY>
        {
            new XY(-1, -1),
            new XY(2, -1),
            new XY(11, -1),
            new XY(10, -1),
            new XY(10, 10),
            new XY(11, 10)
        };

        /// 20x10 Dungeon, empty
        Dungeon Dungeon2;

        /// 10x20 Dungeon, empty
        Dungeon Dungeon3;

        /// 10x10 Dungeon,
        /// [2,2] is wall
        /// [2,3] is closed door
        /// [2,4] is open door
        /// [2,5] is floor
        Dungeon Dungeon4;

        /// <summary>
        /// Test that Width returns correctly
        /// </summary>
        [Test]
        public void WidthTest()
        {
            Assert.AreEqual(Dungeon1.Width, 10, "Width not reported correctly");
            Assert.AreEqual(Dungeon2.Width, 20, "Width not reported correctly");
            Assert.AreEqual(Dungeon3.Width, 10, "Width not reported correctly");
        }

        /// <summary>
        /// Test that Height returns correctly
        /// </summary>
        [Test]
        public void HeightTest()
        {
            Assert.AreEqual(Dungeon1.Height, 10, "Height not reported correctly");
            Assert.AreEqual(Dungeon2.Height, 10, "Height not reported correctly");
            Assert.AreEqual(Dungeon3.Height, 20, "Height not reported correctly");
        }

        /// <summary>
        /// Test that Get/Set of cell works in ordinary circumstances
        /// </summary>
        [Test]
        public void GetSetCellTest()
        {
            Dungeon1.SetCell(new XY(6, 3), Dungeon.DungeonCell.WALL);
            Assert.AreEqual(Dungeon1.GetCell(new XY(6, 3)), Dungeon.DungeonCell.WALL,
                "Dungeon cell not correctly read or set");
        }

        /// <summary>
        /// Test that an out of bounds get cell returns Empty
        /// </summary>
        [Test]
        [TestCaseSource("Dungeon1OutOfBoundsData")] 
        public void GetOutOfBoundsCellTest(XY Coord)
        {
            Assert.AreEqual(Dungeon1.GetCell(Coord), DungeonCell.EMPTY);
        }

        /// <summary>
        /// Test that walkable spaces return true
        /// </summary>
        [Test]
        public void GetWalkableTests()
        {
            Assert.IsTrue(Dungeon4.Walkable(new XY(2, 4)), "Open door not walkable");
            Assert.IsTrue(Dungeon4.Walkable(new XY(2, 5)), "Floor not walkable");
        }

        /// <summary>
        /// Test that unwalkable spaces return false
        /// </summary>
        [Test]
        public void GetUnWalkableTests()
        {
            Assert.IsFalse(Dungeon4.Walkable(new XY(2, 1)), "Empty is walkable");
            Assert.IsFalse(Dungeon4.Walkable(new XY(2, 2)), "Wall is walkable");
            Assert.IsFalse(Dungeon4.Walkable(new XY(2, 3)), "Closed door is walkable");
        }

        /// <summary>
        /// Test that an out of bounds walkable call returns False
        /// </summary>
        [Test]
        [TestCaseSource("Dungeon1OutOfBoundsData")] 
        public void OutOfBoundsWalkableTest(XY Coord)
        {
            Assert.IsFalse(Dungeon1.Walkable(Coord));
        }
    }
}