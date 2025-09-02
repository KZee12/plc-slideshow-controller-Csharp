namespace PLCSlideshowController
{
    public class AssemblyStep
    {
        public int StepNumber { get; set; }
        public int PtlNumber { get; set; } // New Property for Pick-to-Light
        public int PickSlide { get; set; }
        public int PlaceSlide { get; set; }
        public bool IsVideo { get; set; }
        public int CycleTimeSeconds { get; set; }

        /// <summary>
        /// Initializes a new instance of the AssemblyStep class with default values.
        /// </summary>
        public AssemblyStep()
        {
            StepNumber = 1;
            PtlNumber = 0;
            PickSlide = 0;    // A value of 0 indicates the pick step should be skipped.
            PlaceSlide = 1;   // Default to the first slide.
            IsVideo = false;
            CycleTimeSeconds = 5; // A non-zero default to prevent timer errors.
        }
    }
}

