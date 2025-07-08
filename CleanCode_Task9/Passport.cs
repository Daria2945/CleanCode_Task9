namespace CleanCode_Task9
{
    public class Passport
    {
        private readonly string _seriesNumber;

        public Passport(string seriesNumber)
        {
            _seriesNumber = seriesNumber ?? throw new ArgumentNullException(nameof(seriesNumber));
        }

        public string SeriesNumber => _seriesNumber;
    }
}