using SeventhTask.Logic.Components.Builders.Abstracts;

namespace SeventhTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public SequenceBuilder SequenceCreater { get; protected set; }

        public Controller(SequenceBuilder sequenceCreater) 
        {
            SequenceCreater = sequenceCreater;
        }

        public abstract void Display();
        public abstract void SetSequenceCreater(SequenceBuilder sequenceCreater);
    }
}
