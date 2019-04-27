﻿using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Services
{
    public class MatchService : IMatchService
    {
        private readonly IEnumerable<Match> fakeMatches = new List<Match>
        {
            new Match
            {
                Id = 1,
                Local = "Real Madrid",
                Visitor = "PSG",
                Time = "20:00",
                State = MatchState.Finished,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis.",
                ScoreLocal = 2,
                ScoreVisitor = 1
            },
            new Match
            {
                Id = 2,
                Local = "Barcelona",
                Visitor = "Manchester City",
                Time = "19:00",
                State = MatchState.Finished,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis.",
                ScoreLocal = 4,
                ScoreVisitor = 2
            },
            new Match
            {
                Id = 3,
                Local = "Juventus",
                Visitor = "Ajax",
                Time = "21:00",
                State = MatchState.Started,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 4,
                Local = "Manchester City",
                Visitor = "Barcelona",
                Time = "19:45",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 5,
                Local = "Bayern",
                Visitor = "Dortmund",
                Time = "20:45",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 6,
                Local = "Sevilla",
                Visitor = "Liverpool",
                Time = "21:00",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 7,
                Local = "PSG",
                Visitor = "Real Madrid",
                Time = "20:00",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 8,
                Local = "Ajax",
                Visitor = "Juventus",
                Time = "19:00",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 9,
                Local = "Milan",
                Visitor = "Lyon",
                Time = "21:00",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            },
            new Match
            {
                Id = 10,
                Local = "Dortumnd",
                Visitor = "Bayern",
                Time = "20:30",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pellentesque sed dolor vitae iaculis."
            }
        };
        // Fake narration from https://www.flashscore.com/match/WhQHNA8E/#live-commentary;0
        private readonly IEnumerable<MatchMinute> fakeMatchMinutes = new List<MatchMinute> {
            new MatchMinute
            {
                Minute = 1,
                Event = MatchEvent.Default,
                Text = "The referee blows his whistle and we are underway."
            },
            new MatchMinute
            {
                Minute = 3,
                Text = "Donny van de Beek (Ajax) races towards goal but the defender gets back well to make a challenge. The linesman signals a throw-in for Ajax."
            },
            new MatchMinute
            {
                Minute = 6,
                Event = MatchEvent.Injury,
                Text = "The game is interrupted now, Noussair Mazraoui (Ajax) picks up a knock and the physio has to come on."
            },
            new MatchMinute
            {
                Minute = 8,
                Text = "Noussair Mazraoui (Ajax) is moving okay again after that injury scare."
            },
            new MatchMinute
            {
                Minute = 9,
                Text = "Clement Turpin has a clear sight and sees a foul from Daniele Rugani (Juventus)."
            },
            new MatchMinute
            {
                Minute = 11,
                Event = MatchEvent.Change,
                Text = "Erik Ten Hag is forced to make a change. Noussair Mazraoui is unable to continue due to injury, Daley Sinkgraven (Ajax) comes on."
            },
            new MatchMinute
            {
                Minute = 13,
                Text = "Blaise Matuidi (Juventus) escapes without any punishment from the referee after using excessive force to foul his opponent. Ajax win a free kick."
            },
            new MatchMinute
            {
                Minute = 13,
                Text = "Hakim Ziyech (Ajax) sends the free kick into the box, but Wojciech Szczesny leaps to intercept it."
            },
            new MatchMinute
            {
                Minute = 17,
                Text = "Cristiano Ronaldo (Juventus) bursts into the box and latches on to a pin-point long through ball, but one of the defenders steps in to clear the ball to safety."
            },
            new MatchMinute
            {
                Minute = 19,
                Text = "Dusan Tadic (Ajax) commits a foul and Clement Turpin immediately signals a free kick."
            },
            new MatchMinute
            {
                Minute = 21,
                Text = "Donny van de Beek (Ajax) latches onto a loose ball inside the box but slams it high over the bar."
            },
            new MatchMinute
            {
                Minute = 22,
                Event = MatchEvent.Corner,
                Text = "Cristiano Ronaldo (Juventus) takes a first-time shot from the edge of the box, but his effort is well blocked by the defender. The ball is out of play and Juventus manage to earn a corner."
            },
            new MatchMinute
            {
                Minute = 22,
                Text = "Miralem Pjanic (Juventus) takes the resulting corner which is well defended."
            },
            new MatchMinute
            {
                Minute = 23,
                Text = "A big opportunity is wasted by Paulo Dybala (Juventus), who makes a yard for himself and produces a mid-range rocket of a shot towards the right side of the goal. Unfortunately for him, Andre Onana pulls off a fantastic save to stop the effort."
            },
            new MatchMinute
            {
                Minute = 24,
                Event = MatchEvent.Corner,
                Text = "Lasse Schone (Ajax) takes the corner but only sends it into a huddle of the defenders and one of them makes a good clearance."
            },
            new MatchMinute
            {
                Minute = 26,
                Text = "Joel Veltman (Ajax) sends over a cross, but he can't find any teammate inside the box. Poor delivery."
            },
            new MatchMinute
            {
                Minute = 28,
                Event = MatchEvent.Corner,
                Text = "Federico Bernardeschi (Juventus) wriggles into space inside the box with excellent ball control, but his effort on goal is well blocked. Juventus have been awarded a corner kick."
            },
            new MatchMinute
            {
                Minute = 28,
                Text = "Miralem Pjanic (Juventus) takes the corner."
            },
            new MatchMinute
            {
                Minute = 28,
                Event = MatchEvent.Goal,
                Text = "Goal! Miralem Pjanic sent in a fine cross from the corner kick. The perfect pass found Cristiano Ronaldo (Juventus) and his bullet header from around the penalty spot went straight into the right side of the goal. The score is 1:0."
            },
            new MatchMinute
            {
                Minute = 29,
                Event = MatchEvent.Var,
                Text = "The goal for Juventus is subject to a VAR review by the referee! He's obviously unsure or he received a message."
            },
            new MatchMinute
            {
                Minute = 30,
                Event = MatchEvent.Goal,
                Text = "Referee Clement Turpin points to the centre spot to indicate that the goal stands after the VAR review. The Juventus players celebrate."
            },
            new MatchMinute
            {
                Minute = 33,
                Text = "That's a well-taken pass by Cristiano Ronaldo (Juventus). He unleashes a strike from the edge of the box, but blazes it high over the bar."
            },
            new MatchMinute
            {
                Minute = 34,
                Event = MatchEvent.Goal,
                Text = "Donny van de Beek (Ajax) has a great chance inside the box and puts the ball into the back of the net."
            },
            new MatchMinute
            {
                Minute = 35,
                Event = MatchEvent.Var,
                Text = "The Ajax players celebrate the goal but the referee immediately signals a VAR review. Let's see what happens. Big moment in the game."
            },
            new MatchMinute
            {
                Minute = 36,
                Event = MatchEvent.Goal,
                Text = "Referee Clement Turpin takes one last look at the VAR monitor and decides that the goal stands! The Ajax players go wild in celebration."
            },
            new MatchMinute
            {
                Minute = 38,
                Text = "Mattia De Sciglio (Juventus) put a cross into the box which wasn't a bad decision, but he failed to achieve what he wanted as none of his teammates managed to meet it."
            },
            new MatchMinute
            {
                Minute = 40,
                Text = "Emre Can (Juventus) breaks into the box and goes over after a challenge from an opposition player, but the ref signals NO penalty!"
            },
            new MatchMinute
            {
                Minute = 42,
                Text = "Paulo Dybala (Juventus) tries to find Federico Bernardeschi, but he puts too much power on the through ball."
            }
        };

        public IEnumerable<Match> GetNextMatches(int max)
        {
            return this.fakeMatches.Take(max);
        }

        public Match Get(int id)
        {
            var match = this.fakeMatches.FirstOrDefault(x => x.Id == id);
            match.Minutes = this.fakeMatchMinutes.Reverse();

            return match;
        }
    }
}
