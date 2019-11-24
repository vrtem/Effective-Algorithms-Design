namespace pea.other
{
    public interface IAlgorithmsInterface
    {
        Result Result { get; }
        string Name { get; set; }
        void Request();
    }
}