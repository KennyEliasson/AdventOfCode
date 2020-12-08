using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Solutions.Day8
{
    public class Bootloader
    {
        private readonly Regex _commandRegex = new Regex("([a-z]+) (\\+|-)(\\d+)", RegexOptions.Compiled);
        
        public List<Command> Commands { get; set; } = new List<Command>();

        public void Load(List<string> bootInstructionsPayload)
        {
            var index = 0;
            foreach (var instruction in bootInstructionsPayload)
            {
                Match match = _commandRegex.Match(instruction);
                
                if(!match.Success)
                    throw new ApplicationException();

                var cmd = match.Groups[1].Value;
                var sign = match.Groups[2].Value;
                var positionChange = int.Parse(match.Groups[3].Value);

                if (sign == "-")
                {
                    positionChange = positionChange * -1;
                }

                switch (cmd)
                {
                    case "nop":
                        Commands.Add(new NoOpCommand(index, positionChange));
                        break;
                    case "acc":
                        Commands.Add(new AccCommand(index, positionChange));
                        break;
                    case "jmp":
                        Commands.Add(new JmpCommand(index, positionChange));
                        break;
                }
                
                index++;
            }
        }

        public CommandState Execute()
        {
            return Execute(Commands).state;
        }
        
        public CommandState FixProgram()
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                var newCommandList = ChangeCommandList(i);
                var result = Execute(newCommandList);
                if (result.success)
                {
                    return result.state;
                }
            }
            
            throw new ApplicationException();
        }

        private (bool success, CommandState state) Execute(IReadOnlyList<Command> commands)
        {
            var state = new CommandState();

            while (true)
            {
                if (state.CurrentIndex >= commands.Count)
                {
                    return (true, state);
                }
                
                var executeState = commands[state.CurrentIndex].Execute(state);

                if (!executeState)
                {
                    break;
                }
            }
            
            return (false, state);
        }

        public List<Command> ChangeCommandList(int index)
        {
            var newListOfCommands = new List<Command>(Commands);
            
            var command = Commands[index];
            if (command is JmpCommand)
            {
                newListOfCommands.RemoveAt(index);
                newListOfCommands.Insert(index, new NoOpCommand(command.Index, command.PositionChange));
            }
            else if (command is NoOpCommand)
            {
                newListOfCommands.RemoveAt(index);
                newListOfCommands.Insert(index, new JmpCommand(command.Index, command.PositionChange));
            }

            return newListOfCommands;
        }
    }
}