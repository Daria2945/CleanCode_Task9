namespace CleanCode_Task9
{
    public class Citizen
    {
        private readonly Passport _passport;

        public Citizen(Passport passport, bool canVote)
        {
            _passport = passport ?? throw new ArgumentNullException(nameof(passport));
            CanVote = canVote;
        }

        public Passport Passport => _passport;

        public bool CanVote { get; }
    }
}