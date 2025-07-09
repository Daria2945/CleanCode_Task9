using System.Data;

namespace CleanCode_Task9
{
    public class Repository
    {
        private readonly DataBaseContext _context;
        private DataTable _dataTable;

        public Repository(DataBaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Citizen TryFoundCitizen(Passport passport)
        {
            string hashPassport = HashSystem.ComputeSha256Hash(passport.SeriesNumber);
            _dataTable = _context.GetDataTable(hashPassport);

            if (_dataTable.Rows.Count == 0)
                return null;

            int canVoteIndex = 1;
            bool canVote = Convert.ToBoolean(_dataTable.Rows[0].ItemArray[canVoteIndex]);

            return CreateCitizen(passport, canVote); ;
        }

        private Citizen CreateCitizen(Passport passport, bool canVote)
        {
            ArgumentNullException.ThrowIfNull(passport);

            return new Citizen(passport, canVote);
        }
    }
}