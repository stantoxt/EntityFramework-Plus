﻿// Description: EF Bulk Operations & Utilities | Bulk Insert, Update, Delete, Merge from database.
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum: https://github.com/zzzprojects/EntityFramework-Plus/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.



#if STANDALONE && EF7
using System.Data;
using System.Data.Common;

namespace Z.EntityFramework.Plus
{
    internal class CreateEntityCommand : DbCommand
    {
        public CreateEntityCommand(DbCommand originalCommand, DbDataReader originalDataReader)
        {
            OriginalCommand = originalCommand;
            OriginalDataReader = originalDataReader;
        }

        private DbCommand OriginalCommand { get; }

        private DbDataReader OriginalDataReader { get; }

        public override string CommandText
        {
            get { return OriginalCommand.CommandText; }
            set { OriginalCommand.CommandText = value; }
        }

        public override int CommandTimeout
        {
            get { return OriginalCommand.CommandTimeout; }
            set { OriginalCommand.CommandTimeout = value; }
        }

        public override CommandType CommandType
        {
            get { return OriginalCommand.CommandType; }
            set { OriginalCommand.CommandType = value; }
        }

        public override bool DesignTimeVisible
        {
            get { return OriginalCommand.DesignTimeVisible; }
            set { OriginalCommand.DesignTimeVisible = value; }
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get { return OriginalCommand.UpdatedRowSource; }
            set { OriginalCommand.UpdatedRowSource = value; }
        }

        protected override DbConnection DbConnection
        {
            get { return OriginalCommand.Connection; }
            set { OriginalCommand.Connection = value; }
        }

        protected override DbParameterCollection DbParameterCollection
        {
            get { return OriginalCommand.Parameters; }
        }

        protected override DbTransaction DbTransaction
        {
            get { return OriginalCommand.Transaction; }
            set { OriginalCommand.Transaction = value; }
        }

        public override void Cancel()
        {
            OriginalCommand.Cancel();
        }

        public override int ExecuteNonQuery()
        {
            return OriginalCommand.ExecuteNonQuery();
        }

        public override object ExecuteScalar()
        {
            return OriginalCommand.ExecuteScalar();
        }

        public override void Prepare()
        {
            OriginalCommand.Prepare();
        }

        protected override DbParameter CreateDbParameter()
        {
            return OriginalCommand.CreateParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return OriginalDataReader;
        }
    }
}

#endif