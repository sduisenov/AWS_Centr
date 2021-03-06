/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:07
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Awsd5.DataObjects
{
	public partial class DAOLogtables : DATACONN0_BaseData
	{
		#region member variables
		protected Int32? _id;
		protected string _text;
		protected Int64? _type;
		protected DateTime? _time;
		protected Int32? _user;
		#endregion

		#region class methods
		public DAOLogtables()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table logtables based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOLogtables
		///</returns>
		///<parameters>
		///Int32? id
		///</parameters>
		public static DAOLogtables SelectOne(Int32? id)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("logtables");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)id?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOLogtables retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOLogtables();
					retObj._id					 = Convert.IsDBNull(dt.Rows[0]["id"]) ? (Int32?)null : (Int32?)dt.Rows[0]["id"];
					retObj._text					 = Convert.IsDBNull(dt.Rows[0]["text"]) ? null : (string)dt.Rows[0]["text"];
					retObj._type					 = Convert.IsDBNull(dt.Rows[0]["type"]) ? (Int64?)null : (Int64?)dt.Rows[0]["type"];
					retObj._time					 = Convert.IsDBNull(dt.Rows[0]["time"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["time"];
					retObj._user					 = Convert.IsDBNull(dt.Rows[0]["user"]) ? (Int32?)null : (Int32?)dt.Rows[0]["user"];
				}
				return retObj;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Delete one row by primary key(s)
		///this method allows the object to delete itself from the table logtables based on its primary key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows by foreign key
		///This method returns all data rows in the table logtables based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOLogtables.
		///</returns>
		///<parameters>
		///Int32? user
		///</parameters>
		public static IList<DAOLogtables> SelectAllByUser(Int32? user)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAllByUser;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("logtables");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)user?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOLogtables> objList = new List<DAOLogtables>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOLogtables retObj = new DAOLogtables();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._text					 = Convert.IsDBNull(row["text"]) ? null : (string)row["text"];
						retObj._type					 = Convert.IsDBNull(row["type"]) ? (Int64?)null : (Int64?)row["type"];
						retObj._time					 = Convert.IsDBNull(row["time"]) ? (DateTime?)null : (DateTime?)row["time"];
						retObj._user					 = Convert.IsDBNull(row["user"]) ? (Int32?)null : (Int32?)row["user"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///Int32? user
		///</parameters>
		public static Int32 SelectAllByUserCount(Int32? user)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAllByUserCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)user?? (object)DBNull.Value));

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Delete all by foreign key
		///This method deletes all rows in the table logtables with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DATACONN0_TxConnectionProvider connectionProvider, Int32? user
		///</parameters>
		public static void DeleteAllByUser(DATACONN0_TxConnectionProvider connectionProvider, Int32? user)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_DeleteAllByUser;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)user?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Insert a new row
		///This method saves a new object to the table logtables
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Insert()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _id));
				command.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_text?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@type", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_type?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_time?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_user?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_text					 = Convert.IsDBNull(command.Parameters["@text"].Value) ? null : (string)command.Parameters["@text"].Value;
				_type					 = Convert.IsDBNull(command.Parameters["@type"].Value) ? (Int64?)null : (Int64?)command.Parameters["@type"].Value;
				_time					 = Convert.IsDBNull(command.Parameters["@time"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@time"].Value;
				_user					 = Convert.IsDBNull(command.Parameters["@user"].Value) ? (Int32?)null : (Int32?)command.Parameters["@user"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows
		///This method returns all data rows in the table logtables
		///</Summary>
		///<returns>
		///IList-DAOLogtables.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOLogtables> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("logtables");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOLogtables> objList = new List<DAOLogtables>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOLogtables retObj = new DAOLogtables();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._text					 = Convert.IsDBNull(row["text"]) ? null : (string)row["text"];
						retObj._type					 = Convert.IsDBNull(row["type"]) ? (Int64?)null : (Int64?)row["type"];
						retObj._time					 = Convert.IsDBNull(row["time"]) ? (DateTime?)null : (DateTime?)row["time"];
						retObj._user					 = Convert.IsDBNull(row["user"]) ? (Int32?)null : (Int32?)row["user"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SelectAllCount()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAllCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///IList-DAOLogtables.
		///</returns>
		///<parameters>
		///DAOLogtables daoLogtables
		///</parameters>
		public static IList<DAOLogtables> SelectAllBySearchFields(DAOLogtables daoLogtables)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAllBySearchFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("logtables");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Text?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@type", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Type?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Time?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)daoLogtables.User?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOLogtables> objList = new List<DAOLogtables>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOLogtables retObj = new DAOLogtables();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._text					 = Convert.IsDBNull(row["text"]) ? null : (string)row["text"];
						retObj._type					 = Convert.IsDBNull(row["type"]) ? (Int64?)null : (Int64?)row["type"];
						retObj._time					 = Convert.IsDBNull(row["time"]) ? (DateTime?)null : (DateTime?)row["time"];
						retObj._user					 = Convert.IsDBNull(row["user"]) ? (Int32?)null : (Int32?)row["user"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///DAOLogtables daoLogtables
		///</parameters>
		public static Int32 SelectAllBySearchFieldsCount(DAOLogtables daoLogtables)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_SelectAllBySearchFieldsCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Text?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@type", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Type?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoLogtables.Time?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)daoLogtables.User?? (object)DBNull.Value));

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Update one row by primary key(s)
		///This method allows the object to update itself in the table logtables based on its primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Update()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprlogtables_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_text?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@type", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_type?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_time?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_user?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_text					 = Convert.IsDBNull(command.Parameters["@text"].Value) ? null : (string)command.Parameters["@text"].Value;
				_type					 = Convert.IsDBNull(command.Parameters["@type"].Value) ? (Int64?)null : (Int64?)command.Parameters["@type"].Value;
				_time					 = Convert.IsDBNull(command.Parameters["@time"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@time"].Value;
				_user					 = Convert.IsDBNull(command.Parameters["@user"].Value) ? (Int32?)null : (Int32?)command.Parameters["@user"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		#endregion

		#region member properties

		public Int32? Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}

		public Int64? Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public DateTime? Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}

		public Int32? User
		{
			get
			{
				return _user;
			}
			set
			{
				_user = value;
			}
		}

		#endregion
	}
}

#region inline sql procs
namespace Awsd5.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprlogtables_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[id]
			,[text]
			,[type]
			,[time]
			,[user]
			FROM [dbo].[logtables]
			WHERE 
			[id] = @id
			";

		internal static string ctprlogtables_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[logtables]
			WHERE 
			[id] = @id
			";

		internal static string ctprlogtables_SelectAllByUser = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[id]
			,[text]
			,[type]
			,[time]
			,[user]
			FROM [dbo].[logtables]
			WHERE 
			[user] = @user OR ([user] IS NULL AND @user IS NULL)
			";

		internal static string ctprlogtables_SelectAllByUserCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[logtables]
			WHERE 
			[user] = @user OR ([user] IS NULL AND @user IS NULL)
			";

		internal static string ctprlogtables_DeleteAllByUser = @"
			
			-- delete all matching from the table
			DELETE [dbo].[logtables]
			WHERE 
			[user] = @user OR ([user] IS NULL AND @user IS NULL)
			";

		internal static string ctprlogtables_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[logtables]
			(
			[text]
			,[type]
			,[time]
			,[user]
			)
			VALUES
			(
			@text
			,@type
			,@time
			,@user
			)
			SELECT 
			@id = [id]
			,@text = [text]
			,@type = [type]
			,@time = [time]
			,@user = [user]
			FROM [dbo].[logtables]
			WHERE 
			id = SCOPE_IDENTITY()
			";

		internal static string ctprlogtables_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[id]
			,[text]
			,[type]
			,[time]
			,[user]
			FROM [dbo].[logtables]
			";

		internal static string ctprlogtables_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[logtables]
			";

		internal static string ctprlogtables_SelectAllBySearchFields = @"
			
			-- selects all rows from the table according to search criteria
			SELECT 
			[id],
			[text],
			[type],
			[time],
			[user]
			FROM [dbo].[logtables]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([text] LIKE @text OR @text is null)
			AND ([type] LIKE @type OR @type is null)
			AND ([time] LIKE @time OR @time is null)
			AND ([user] LIKE @user OR @user is null)
			";

		internal static string ctprlogtables_SelectAllBySearchFieldsCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table according to search criteria
			SELECT COUNT(*)
			FROM [dbo].[logtables]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([text] LIKE @text OR @text is null)
			AND ([type] LIKE @type OR @type is null)
			AND ([time] LIKE @time OR @time is null)
			AND ([user] LIKE @user OR @user is null)
			";

		internal static string ctprlogtables_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[logtables]
			SET
			[text] = @text
			,[type] = @type
			,[time] = @time
			,[user] = @user
			WHERE 
			[id] = @id
			SELECT 
			@id = [id]
			,@text = [text]
			,@type = [type]
			,@time = [time]
			,@user = [user]
			FROM [dbo].[logtables]
			WHERE 
			[id] = @id
			";

	}
}
#endregion
