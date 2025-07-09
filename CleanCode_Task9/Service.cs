namespace CleanCode_Task9
{
    public class Service : IService
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Citizen TryFoundCitizen(Passport passport)
        {
            Citizen citizen = _repository.TryFoundCitizen(passport);

            if (citizen != null)
                return citizen;
            else
                return null;
        }
    }
}