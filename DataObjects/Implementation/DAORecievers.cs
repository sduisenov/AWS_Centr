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
	public partial class DAORecievers : DATACONN0_BaseData
	{
		#region member variables
		protected Int32? _id;
		protected Int64? _externalid;
		protected string _shortname;
		protected string _name;
		#endregion

		#region class methods
		public DAORecievers()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table recievers based on the primary key(s)
		///</Summary>
		///<returns>
		///DAORecievers
		///</returns>
		///<parameters>
		///Int32? id
		///</parameters>
		public static DAORecievers SelectOne(Int32? id)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprrecievers_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("recievers");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)id?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAORecievers retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAORecievers();
					retObj._id					 = Convert.IsDBNull(dt.Rows[0]["id"]) ? (Int32?)null : (Int32?)dt.Rows[0]["id"];
					retObj._externalid					 = Convert.IsDBNull(dt.Rows[0]["externalid"]) ? (Int64?)null : (Int64?)dt.Rows[0]["externalid"];
					retObj._shortname					 = Convert.IsDBNull(dt.Rows[0]["shortname"]) ? null : (string)dt.Rows[0]["shortname"];
					retObj._name					 = Convert.IsDBNull(dt.Rows[0]["name"]) ? null : (string)dt.Rows[0]["name"];
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
		///this method allows the object to delete itself from the table recievers based on its primary key
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
			command.CommandText = InlineProcs.ctprrecievers_DeleteOne;
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
		///Insert a new row
		///This method saves a new object to the table recievers
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
			command.CommandText = InlineProcs.ctprrecievers_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _id));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;

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
		///This method returns all data rows in the table recievers
		///</Summary>
		///<returns>
		///IList-DAORecievers.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORecievers> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprrecievers_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("recievers");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORecievers> objList = new List<DAORecievers>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORecievers retObj = new DAORecievers();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
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
			command.CommandText = InlineProcs.ctprrecievers_SelectAllCount;
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
		///IList-DAORecievers.
		///</returns>
		///<parameters>
		///DAORecievers daoRecievers
		///</parameters>
		public static IList<DAORecievers> SelectAllBySearchFields(DAORecievers daoRecievers)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprrecievers_SelectAllBySearchFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("recievers");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Name?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORecievers> objList = new List<DAORecievers>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORecievers retObj = new DAORecievers();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
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
		///DAORecievers daoRecievers
		///</parameters>
		public static Int32 SelectAllBySearchFieldsCount(DAORecievers daoRecievers)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprrecievers_SelectAllBySearchFieldsCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoRecievers.Name?? (object)DBNull.Value));

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
		///This method allows the object to update itself in the table recievers based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprrecievers_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;

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

		public Int64? Externalid
		{
			get
			{
				return _externalid;
			}
			set
			{
				_externalid = value;
			}
		}

		public string Shortname
		{
			get
			{
				return _shortname;
			}
			set
			{
				_shortname = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
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
		internal static string ctprrecievers_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[shortname]
			,[name]
			FROM [dbo].[recievers]
			WHERE 
			[id] = @id
			";

		internal static string ctprrecievers_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[recievers]
			WHERE 
			[id] = @id
			";

		internal static string ctprrecievers_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[recievers]
			(
			[externalid]
			,[shortname]
			,[name]
			)
			VALUES
			(
			@externalid
			,@shortname
			,@name
			)
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@shortname = [shortname]
			,@name = [name]
			FROM [dbo].[recievers]
			WHERE 
			id = SCOPE_IDENTITY()
			";

		internal static string ctprrecievers_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[shortname]
			,[name]
			FROM [dbo].[recievers]
			";

		internal static string ctprrecievers_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[recievers]
			";

		internal static string ctprrecievers_SelectAllBySearchFields = @"
			
			-- selects all rows from the table according to search criteria
			SELECT 
			[id],
			[externalid],
			[shortname],
			[name]
			FROM [dbo].[recievers]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			AND ([name] LIKE @name OR @name is null)
			";

		internal static string ctprrecievers_SelectAllBySearchFieldsCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table according to search criteria
			SELECT COUNT(*)
			FROM [dbo].[recievers]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			AND ([name] LIKE @name OR @name is null)
			";

		internal static string ctprrecievers_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[recievers]
			SET
			[externalid] = @externalid
			,[shortname] = @shortname
			,[name] = @name
			WHERE 
			[id] = @id
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@shortname = [shortname]
			,@name = [name]
			FROM [dbo].[recievers]
			WHERE 
			[id] = @id
			";

	}
}
#endregion
