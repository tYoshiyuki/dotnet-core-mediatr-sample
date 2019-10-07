namespace DotNetCoreMediatrSample.Domain.Domain.Circles
{
    public interface ICircleRepository
    {
        Circle Find(CircleId id);
        void Save(Circle circle);

    }
}
