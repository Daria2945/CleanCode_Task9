namespace CleanCode_Task9
{
    public class Passport
    {
        private const string MissingDataMessage = "Введите серию и номер паспорта";
        private const string InvalidFormatMessage = "Неверный формат серии или номера паспорта";
        private const int LengthPassportInfo = 10;

        public Passport(string seriesNumber)
        {
            if (seriesNumber.Trim() == string.Empty)
                throw new ArgumentException(MissingDataMessage);

            string space = " ";
            string rawData = seriesNumber.Trim().Replace(space, string.Empty);

            if (rawData.Length != LengthPassportInfo)
                throw new ArgumentException(InvalidFormatMessage);

            SeriesNumber = rawData;
        }

        public string SeriesNumber { get; }
    }
}