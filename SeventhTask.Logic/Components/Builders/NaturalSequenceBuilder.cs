using SeventhTask.Logic.Components.Interfaces;
using SeventhTask.Logic.Components.Builders.Abstracts;

namespace SeventhTask.Logic.Components.Builders
{
    public class NaturalSequenceBuilder : SequenceBuilder
    {
        public NaturalSequenceBuilder(double maxRange) : base(maxRange) 
        {
        }

        public override ISequence Create()
        {
            return new NaturalSequence(MaxRange);
        }
    }
}
