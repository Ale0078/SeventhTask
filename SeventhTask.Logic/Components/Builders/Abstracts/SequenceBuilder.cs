using SeventhTask.Logic.Components.Interfaces;

namespace SeventhTask.Logic.Components.Builders.Abstracts
{
    public abstract class SequenceBuilder
    {
        public double MaxRange { get; }

        public SequenceBuilder(double maxRange) 
        {
            MaxRange = maxRange;
        }

        public abstract ISequence Create();
    }
}
