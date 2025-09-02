using System.Collections.Generic;

namespace PLCSlideshowController
{
    /// <summary>
    /// Represents the entire configuration for a single SOP slideshow.
    /// </summary>
    public class SopConfiguration
    {
        public int EndSlide { get; set; }
        public List<AssemblyStep> Steps { get; set; }

        public SopConfiguration()
        {
            EndSlide = 15; // Default value
            Steps = new List<AssemblyStep>();
        }
    }
}
