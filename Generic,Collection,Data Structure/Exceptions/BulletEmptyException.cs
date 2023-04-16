namespace Generic_Collection_Data_Structure.Exceptions;

public class BulletEmptyException : Exception
{
    public BulletEmptyException() : base("Bullet is empty")
    {

    }
    public BulletEmptyException(string message) : base(message)
    {

    }
}
