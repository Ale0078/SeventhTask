using System.Text;
using NLog;

using static System.Console;

using SeventhTask.Messages;
using SeventhTask.Logic.Components.Interfaces;
using SeventhTask.Logic.Components.Builders.Abstracts;
using SeventhTask.Logic.UserInterface.Abstracts;

namespace SeventhTask.Controllers
{
    public class SequenceController : Controller
    {
        private readonly ILogger _logger;

        public SequenceController(SequenceBuilder sequenceCreater) : base(sequenceCreater)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void Display()
        {
            ISequence naturalSequance = SequenceCreater.Create();

            _logger.Info(LogMessage.DISPLAY_CREATE_SEQUENCE);

            StringBuilder output = new();

            foreach (var number in naturalSequance) 
            {
                output.Append(number);
                output.Append(", ");
            }

            WriteLine(output);

            _logger.Info(LogMessage.DISPLAY_OUTPUT);
        }

        public override void SetSequenceCreater(SequenceBuilder sequenceCreater)
        {
            SequenceCreater = sequenceCreater;

            _logger.Info(LogMessage.SET_SEQUENCE_CREATER);
        }
    }
}
