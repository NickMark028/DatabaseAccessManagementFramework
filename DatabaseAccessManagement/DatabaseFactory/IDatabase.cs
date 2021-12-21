namespace DatabaseAccessManagement
{
	public interface IDatabase
	{
		IConnection CreateConnection();
	}
}
