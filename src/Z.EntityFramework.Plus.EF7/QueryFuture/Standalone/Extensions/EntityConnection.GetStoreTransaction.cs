﻿// Description: EF Bulk Operations & Utilities | Bulk Insert, Update, Delete, Merge from database.
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum: https://github.com/zzzprojects/EntityFramework-Plus/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.



#if STANDALONE && (EF5 || EF6)
using System.Data.Common;
using System.Reflection;
#if EF5
using System.Data.EntityClient;

#elif EF6
using System.Data.Entity.Core.EntityClient;

#endif

namespace Z.EntityFramework.Plus
{
    public static partial class QueryFutureExtensions
    {
        /// <summary>An EntityConnection extension method that gets the store transaction.</summary>
        /// <param name="entityConnection">The entity connection to act on.</param>
        /// <returns>The store transaction from the entity connection.</returns>
        internal static DbTransaction GetStoreTransaction(this EntityConnection entityConnection)
        {
            var entityTransaction = entityConnection.GetEntityTransaction();

            if (entityTransaction == null)
            {
                return null;
            }

            var storeTransactionProperty = entityTransaction.GetType().GetProperty("StoreTransaction", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (DbTransaction) storeTransactionProperty.GetValue(entityTransaction, null);
        }
    }
}
#endif