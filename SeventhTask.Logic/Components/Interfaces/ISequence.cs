using System.Collections.Generic;

namespace SeventhTask.Logic.Components.Interfaces
{
    public interface ISequence
    {
        double MaxRange { get; set; }

        IEnumerator<int> GetEnumerator();
    }
}
