namespace Input.Interface
{
    public interface IInputService
    {
        public IMoveInput GetInputModel();
        public IMoveInput GetAlternativeInputModel();
        public void InitiateInputs();
    }
}