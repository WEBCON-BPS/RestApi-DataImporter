using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Helpers
{
    public class ProgressCounter
    {
        public ProgressCounter(int elements)
        {
            Elements = elements;
        }

        public void Append(ElementResult result)
        {
            Elements--;

            if (result.Error != null)
            {
                Errors++;
                return;
            }

            if (result.Success.status.Equals("Saved"))
            {
                Updated++;
                return;
            }

            Started++;
        }

        public int Elements { get; private set; } = 0;
        public int Started { get; private set; } = 0;
        public int Updated { get; private set; } = 0;
        public int Errors { get; private set; } = 0;
    }
}
