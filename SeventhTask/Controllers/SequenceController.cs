using System.Text;
using NLog;

using static System.Console;

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

            _logger.Info("Sequence was created (SequenceController.Display)");

            StringBuilder output = new();

            foreach (var number in naturalSequance) 
            {
                output.Append(number);
                output.Append(", ");
            }

            WriteLine(output);

            _logger.Info("Sequence was outputted into console (SequenceController.Display)");
        }

        public override void SetSequenceCreater(SequenceBuilder sequenceCreater)
        {
            SequenceCreater = sequenceCreater;

            _logger.Info("New SequenceCreatere was created (SequenceController.SetSequenceCreater)");
        }
    }
}
