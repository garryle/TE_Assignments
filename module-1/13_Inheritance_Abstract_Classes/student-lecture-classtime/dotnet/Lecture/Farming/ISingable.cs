using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISingable
    {
        /// <summary>
        /// the singable items name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// the single sound the item makes
        /// </summary>
        /// <returns></returns>
        string MakeSoundOnce();

        /// <summary>
        /// the double sound the item makes
        /// </summary>
        /// <returns></returns>
        string MakeSoundTwice();
    }
}
