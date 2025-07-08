namespace CleanCode_Task9
{
    public class Service
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public event Action<Citizen> CitizenFoundInDataBase;
        public event Action<Passport> CitizenNotFoundInDataBase;

        public void TryFoundCitizen(Passport passport)
        {
            if (_repository.TryFoundCitizen(passport, out Citizen citizen))
                CitizenFoundInDataBase?.Invoke(citizen);
            else
                CitizenNotFoundInDataBase?.Invoke(passport);
        }
    }
}