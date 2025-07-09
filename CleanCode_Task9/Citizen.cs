namespace CleanCode_Task9
{
    public class Citizen
    {
        public Citizen(Passport passport, bool canVote)
        {
            Passport = passport ?? throw new ArgumentNullException(nameof(passport));
            CanVote = canVote;
        }

        public Passport Passport { get; }

        public bool CanVote { get; }
    }
}