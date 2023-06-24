using Dapper;

public static class DapperExtensions
{
    public static DynamicParameters ToDynamicParameters<T>(this T entity)
    {
        var dynamicParameters = new DynamicParameters();
        var entityType = typeof(T);

        foreach (var propertyInfo in entityType.GetProperties())
        {
            var propertyName = propertyInfo.Name;
            var propertyValue = propertyInfo.GetValue(entity);

            dynamicParameters.Add(propertyName, propertyValue);
        }

        return dynamicParameters;
    }
}