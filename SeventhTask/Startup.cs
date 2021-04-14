using System;
using NLog;

using static System.Console;

using SeventhTask.Controllers;
using SeventhTask.Messages;
using SeventhTask.Logic.UserInterface.Abstracts;
using SeventhTask.Logic.Components.Builders;
using LibToTasks.Validation.Interfaces;
using LibToTasks.Builders;

namespace SeventhTask
{
    public class Startup
    {
        private readonly ILogger _logger;
        private readonly IValidator _validatorMaxRange;
        private readonly ITransformator _transformatorMaxRange;
        private readonly string[] _mainArguments;

        public Startup(string[] mainArguments) 
        {
            _mainArguments = mainArguments;

            _logger = LogManager.GetCurrentClassLogger();
            _validatorMaxRange = new DefaultValidatorBuilder().Create();
            _transformatorMaxRange = new DefaultTransformatorBuilder().Create();
        }

        public void Start() 
        {
            if (_mainArguments.Length < 1)
            {
                _logger.Error(LogMessage.STARTUP_ERROR_LENGTH +
                    UserMessage.INSTRACTION, double.MaxValue, double.MinValue);

                WriteLine(UserMessage.INSTRACTION, double.MaxValue, double.MinValue);

                return;
            }

            try
            {
                Controller sequenceController = GetController(CheckConvertValue(_mainArguments[0]));

                sequenceController.Display();
            }
            catch(FormatException ex)
            {
                WriteLine(UserMessage.INSTRACTION, double.MaxValue, double.MinValue);

                _logger.Error(ex + ex.Message + "\n" +
                    UserMessage.INSTRACTION, double.MaxValue, double.MinValue);
            }

            _logger.Info(LogMessage.FINALIZE);
        }

        private Controller GetController(double maxRangeOfSequence) 
        {
            try
            {
                return new SequenceController(
                        sequenceCreater: new NaturalSequenceBuilder(maxRangeOfSequence));
            }
            finally 
            {
                _logger.Info(LogMessage.GET_CONTROLLER);
            }
        }

        private double CheckConvertValue(string valueToDouble) 
        {
            double doubleValue = _transformatorMaxRange.ConfirmConversion<double, string>(valueToDouble);

            _validatorMaxRange.CheckValue(doubleValue =>
            {
                if (doubleValue == double.MaxValue)
                {
                    return false;
                }

                return true;
            }, doubleValue);

            return doubleValue;
        }
    }
}
