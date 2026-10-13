using System.Collections;

namespace ScoutAPI.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        private string Name { get; set; } = string.Empty;
        private Hashtable skillsList { get; set; } = new Hashtable();

        public Player() 
        {
            AddSkills(Skills.Stamina, 3);
        }

        public void AddSkills(Skills skill, int value)
        {
            skillsList.Add(skill, value);
        }

        public enum Skills
        {
            Speed,
            Acceleration,
            Stamina,
            Strength,
            Agility,
            Passing,
            Shooting,
            Dribbling,
            Ballcontrol,
            FirstTouch,
            Crossing,
            Tackling,
            Vision,
            DecisionMaking,
            Composure,
            OffTheBallMovement,
            WorkRate
        }

        /*
        Athletik (Physical)

        Speed – Höchstgeschwindigkeit

        Acceleration – Antritt

        Stamina – Ausdauer

        Strength – Körperkraft

        Agility – Beweglichkeit

        Technik (Technical)

        Passing – Passspiel

        Shooting – Abschluss

        Dribbling – Dribbling

        BallControl – Ballkontrolle

        FirstTouch – erster Ballkontakt

        Crossing – Flanken

        Tackling – Tacklings

        Spielverständnis (Mental / Tactical)

        Vision – Übersicht

        DecisionMaking – Entscheidungsfindung

        Composure – Ruhe unter Druck

        OffTheBallMovement – Bewegung ohne Ball

        WorkRate – Einsatzbereitschaft
         */

    }
}
