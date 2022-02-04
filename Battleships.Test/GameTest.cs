using System;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(1);
        }

        [Fact]
        public void TestPlay1()
        {
            var ships = new[] { "3:2,3:5", "2:2,2:3" };
            var guesses = new[] { "7:0", "3:3", "2:2" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        [Fact]
        public void TestRepeatHit()
        {
            var ships = new[] { "3:2,3:5", "1:1,5:1" };
            var guesses = new[] { "3:3", "4:1", "3:1" };
            Game.Play(ships, guesses).Should().Be(2);
        }

        [Fact]
        public void TestBadShipShape()
        {
            var ships = new[] { "3:2,4:5" };
            var guesses = new[] { "7:0", "3:3" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Ship 3:2,4:5 is the wrong shape");
        }

        [Fact]
        public void TestBadGuess()
        {

            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3-3" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Coordinate 3-3 badly formatted");
        }

        [Fact]
        public void TestBadShip()
        {
            var ships = new[] { "3:2,3:5", "7:0-7:0" };
            var guesses = new[] { "7:0", "3:3" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Ship 7:0-7:0 badly formatted");
        }

        [Fact]
        public void TestGuessOutOfBounds()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "10:0" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Coordinate 10:0 is out of bounds 0-9, 0-9");
        }

        [Fact]
        public void TestShipTooShort()
        {
            var ships = new[] { "3:2,3:2" };
            var guesses = new[] { "0:0" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Ship 3:2,3:2 must be at least 2 units long");
        }

        [Fact]
        public void TestShipTooLong()
        {
            var ships = new[] { "3:2,3:8" };
            var guesses = new[] { "0:0" };
            Action action = () => Game.Play(ships, guesses);
            action.Should().Throw<ArgumentException>().WithMessage("Ship 3:2,3:8 too long");
        }
    }
}
