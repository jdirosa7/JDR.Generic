using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.Generic.Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace JDR.Generic.Data
{
    public class MovementDAC : DataAccessComponent, IMovementRepository
    {
        public List<BankOperation> GetLastMovementsByAccount(Account account)
        {
            const string SQL_STATEMENT = "SELECT M.SourceAccountID, " +
                "M.MovementTypeID, MT.Name as MovementTypeName M.TargetAccountID, M.Value, A.Number, A.AccountTypeID, A.Balance, " +
                "AT.AccountTypeName from Movements M inner join Accounts A on M.SourceAccountID = A.ID " +
                "inner join AccountTypes AT on A.AccountTypeID = AT.ID" +
                "inner join MovementTypes MT on M.MovementTypeID = MT.ID " +
                "where SourceAccountID= @SourceAccountID " +
                "union" +
                "SELECT M.SourceAccountID, " +
                "M.MovementTypeID, MT.Name as MovementTypeName M.TargetAccountID, M.Value, A.Number, A.AccountTypeID, A.Balance, " +
                "AT.AccountTypeName from Movements M inner join Accounts A on M.SourceAccountID = A.ID " +
                "inner join AccountTypes AT on A.AccountTypeID = AT.ID" +
                "inner join MovementTypes MT on M.MovementTypeID = MT.ID " +
                "where TargetAccountID= @TargetAccountID";

            List<BankOperation> result = new List<BankOperation>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        BankOperation movement = LoadMovement(dr);
                        result.Add(movement);
                    }
                }
            }
            return result;
        }

        private BankOperation LoadMovement(IDataReader dr)
        {
            BankOperation operation = new BankOperation
            {
                MovementType = new MovementType
                {
                    Id = GetDataValue<int>(dr, "MovementTypeID"),
                    Name = GetDataValue<string>(dr, "MovementTypeName")
                },
                SourceAccount = new Account
                {
                    Id = GetDataValue<int>(dr, "SourceAccountID"),
                    AccountNumber = GetDataValue<string>(dr, "AccountNumber"),
                    Balance = GetDataValue<decimal>(dr, "Balance")
                },
                TargetAccount = new Account
                {
                    Id = GetDataValue<int>(dr, "SourceAccountID"),
                    AccountNumber = GetDataValue<string>(dr, "AccountNumber"),
                    Balance = GetDataValue<decimal>(dr, "Balance")
                },
                Value = GetDataValue<decimal>(dr, "Value")
            };
            return operation;
        }
    }
}
