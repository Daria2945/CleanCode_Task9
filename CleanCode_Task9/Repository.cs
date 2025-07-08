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

        public bool TryFoundCitizen(Passport passport, out Citizen citizen)
        {
            citizen = null;
            string hashPassport = HashSystem.ComputeSha256Hash(passport.SeriesNumber);

            _context.GetDataTable(hashPassport);

            if (_dataTable.Rows.Count == 0)
                return false;

            int canVoteIndex = 1;
            bool canVote = Convert.ToBoolean(_dataTable.Rows[0].ItemArray[canVoteIndex]);

            citizen = CreateCitizen(passport, canVote);

            return true;
        }

        private Citizen CreateCitizen(Passport passport, bool canVote)
        {
            ArgumentNullException.ThrowIfNull(passport);

            return new Citizen(passport, canVote);
        }
    }
}