﻿using STVRogue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STVRogue.GameLogic
{
	public class XTest_Items
	{
        int hp_before_hp_potion;

        Player p;
        Crystal c;
        HealingPotion hp_potion;
        Item i;
        
        [Fact]
        public void IfPlayerUsesHPpotion_AndHPIsBase_ThenHpIsTheSame() {
            p = new Player();
            hp_before_hp_potion = p.GetHP();
            hp_potion = new HealingPotion("1");

            p.bag.Add(hp_potion);
            p.Use(hp_potion);

            Assert.Equal(p.GetHP(), hp_before_hp_potion);
        }

        /* if the first test runs, then we can safely use an arbitrary value as HP as parameter */
        [Theory]
        [MemberData(nameof(HPData))]
        public void IfPlayerUsesHPpotion_AndHPIsLessThanBase_HPIsRestored (int value) {
            Player p = new Player {
                HP = value
            };

            // HP heals 25 hp. 
            hp_potion = new HealingPotion("2");

            p.bag.Add(hp_potion);
            p.Use(hp_potion);

            if (value >= 7)
                Assert.Equal(10, p.HP);
            else 
                Assert.NotEqual(10, p.HP);
        }

        [Fact]
        public void IfHealingPotion_IsHealingPotionReturnTrue ()
        {
            hp_potion = new HealingPotion("3");

            Assert.True(hp_potion.IsHealingPotion);
        }

        [Fact]
        public void IfCrystal_IsCrystalReturnTrue()
        {
            c = new Crystal("1");
            
            Assert.True(c.IsCrystal);
        }

        [Fact]
        public void IfItem_IsHealingPotion_OrCrystal_ReturnFalse()
        {
            i = new Item("1");
           
            Assert.False(i.IsHealingPotion);
            Assert.False(i.IsCrystal);
        }

        [Fact]
        public void IfItemIsUsedByPlayer_UsedIsTrue() {
            p = new Player();
            hp_potion = new HealingPotion("4");

            Assert.False(hp_potion.used);

            p.bag.Add(hp_potion);
            p.Use(hp_potion);

            Assert.True(hp_potion.used);

            p.Use(hp_potion);

            Assert.
        }
        public static IEnumerable<object[]> HPData =>
            new List<object[]> { 
                new object[] { 0 },
                new object[] { 1 },
                new object[] { 2 },
                new object[] { 3 },
                new object[] { 4 },
                new object[] { 5 },
                new object[] { 6 },
                new object[] { 7 },
                new object[] { 8 },
                new object[] { 9 },
            };
        }



}