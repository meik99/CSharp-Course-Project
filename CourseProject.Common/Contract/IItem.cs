namespace CourseProject.Common.Contract
{
    public interface IItem
    {
        int Id { get; }
        string Description { get; }
        double Amount { get; }
    }
}