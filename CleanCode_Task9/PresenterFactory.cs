namespace CleanCode_Task9
{
    public class PresenterFactory
    {
        private IService _service;

        public PresenterFactory(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IPresenter Create(IView view)
        {
            return new Presenter(view, _service);
        }
    }
}