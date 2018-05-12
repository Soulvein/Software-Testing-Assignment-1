﻿using STVRogue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STVRogue.GameLogic
{
	public class XTest_Game
	{

		
		[Fact]
		public void checkIfValidDungeon()
		{
			Dungeon dungeon = new Dungeon(10, 2);
			Predicates p = new Predicates();
			Assert.True(p.isValidDungeon(dungeon.startNode, dungeon.exitNode, dungeon.difficultyLevel));
		}
		[Fact]
		public void checkIfTooManyMonstersThrowsException()
		{
            Assert.Throws<GameCreationException>(() => new Game(5, 2, 300));
		}

        [Fact]
        public void XTest_disconnect_nodes()
        {
            Node node1 = new Node("1");
            Node node2 = new Node("2");
            Predicates p = new Predicates();
            node1.Connect(node2);
            Assert.True(p.isReachable(node1, node2));
            node1.Disconnect(node2);
            Assert.False(p.isReachable(node1, node2));
        }

        [Fact]
        public void XTest_shortest_path()
        {
            
            Node node1 = new Node("1");
            Node node2 = new Node("2");
            Node node3 = new Node("3");
            Node node4 = new Node("4");
            Node node5 = new Node("5");
            Node node6 = new Node("6");
            Node node7 = new Node("7");
            node1.Connect(node2);
            node2.Connect(node3);
            node3.Connect(node4);
            node4.Connect(node5);
            node1.Connect(node6);
            node6.Connect(node7);
            node7.Connect(node5);
            Dungeon d = new Dungeon(1, 2);
            d.nodeList = new List<Node>() { node1, node2, node3, node4, node5, node6, node7 };
            Assert.Equal(d.Shortestpath(node1, node5), new List<Node>() { node1, node6, node7, node5 });
        }

        [Fact]
        public void XTest_shortest_path_unreachable()
        {
            Node node1 = new Node("1");
            Node node2 = new Node("2");
            Node node3 = new Node("3");
            Node node4 = new Node("4");
            node1.Connect(node2);
            node3.Connect(node4);
            Dungeon d = new Dungeon(1, 2);
            d.nodeList = new List<Node>() { node1, node2, node3, node4 };
            Assert.Equal(d.Shortestpath(node1, node4), new List<Node>() { node1 });
        }
	}
}