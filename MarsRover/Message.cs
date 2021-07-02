using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }


        public Message() { }
       
        public Message(string name, Command[] commands)
        {
            Name = name;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Name required.");
            }
            Commands = commands;
        }
    }
}
