public interface IStateHandle
{
    bool CanHandle();
    void Handle();
}