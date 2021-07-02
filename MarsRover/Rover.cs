using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        public void ReceiveMessage(Message message)
        {
            foreach (Command command in message.Commands)
            {
                if (command.CommandType == "MODE_CHANGE")
                {
                    if (Mode == "NORMAL") Mode = "LOW_POWER";
                    else Mode = "NORMAL";
                }
            }
        }

    }
}
