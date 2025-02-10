using System.Data;
using System.Data.Common;
using ToDay_Shop.Payments.Core.Resources.Utilities.Extensions;
using ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common.Extensions;

namespace ToDay_Shop.Payments.Infrastructor.Data.PostgreSql.Commands.Common.Extensions;

public static class DbCommandExtension
{
    public static void ApplyCorrectYeKe(this DbCommand command)
    {
        command.CommandText = command.CommandText.ApplyCorrectYeKe();

        foreach (DbParameter parameter in command.Parameters)
        {
            switch (parameter.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.Xml:
                    parameter.Value = parameter.Value is DBNull ? parameter.Value : parameter.Value.ApplyCorrectYeKe();
                    break;
            }
        }
    }
}