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
	public partial class DAOOperations : DATACONN0_BaseData
	{
		#region member variables
		protected Int32? _id;
		protected Int64? _externalid;
		protected string _name;
		protected string _shortname;
		#endregion

		#region class methods
		public DAOOperations()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table operations based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOOperations
		///</returns>
		///<parameters>
		///Int32? id
		///</parameters>
		public static DAOOperations SelectOne(Int32? id)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctproperations_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("operations");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)id?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOOperations retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOOperations();
					retObj._id					 = Convert.IsDBNull(dt.Rows[0]["id"]) ? (Int32?)null : (Int32?)dt.Rows[0]["id"];
					retObj._externalid					 = Convert.IsDBNull(dt.Rows[0]["externalid"]) ? (Int64?)null : (Int64?)dt.Rows[0]["externalid"];
					retObj._name					 = Convert.IsDBNull(dt.Rows[0]["name"]) ? null : (string)dt.Rows[0]["name"];
					retObj._shortname					 = Convert.IsDBNull(dt.Rows[0]["shortname"]) ? null : (string)dt.Rows[0]["shortname"];
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
		///this method allows the object to delete itself from the table operations based on its primary key
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
			command.CommandText = InlineProcs.ctproperations_DeleteOne;
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
		///This method saves a new object to the table operations
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
			command.CommandText = InlineProcs.ctproperations_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _id));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;

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
		///This method returns all data rows in the table operations
		///</Summary>
		///<returns>
		///IList-DAOOperations.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOOperations> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctproperations_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("operations");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperations> objList = new List<DAOOperations>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperations retObj = new DAOOperations();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
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
			command.CommandText = InlineProcs.ctproperations_SelectAllCount;
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
		///IList-DAOOperations.
		///</returns>
		///<parameters>
		///DAOOperations daoOperations
		///</parameters>
		public static IList<DAOOperations> SelectAllBySearchFields(DAOOperations daoOperations)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctproperations_SelectAllBySearchFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("operations");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoOperations.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoOperations.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoOperations.Name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoOperations.Shortname?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperations> objList = new List<DAOOperations>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperations retObj = new DAOOperations();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
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
		///DAOOperations daoOperations
		///</parameters>
		public static Int32 SelectAllBySearchFieldsCount(DAOOperations daoOperations)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctproperations_SelectAllBySearchFieldsCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoOperations.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoOperations.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoOperations.Name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoOperations.Shortname?? (object)DBNull.Value));

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
		///This method allows the object to update itself in the table operations based on its primary key(s)
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
			command.CommandText = InlineProcs.ctproperations_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;

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

		#endregion
	}
}

#region inline sql procs
namespace Awsd5.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctproperations_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[name]
			,[shortname]
			FROM [dbo].[operations]
			WHERE 
			[id] = @id
			";

		internal static string ctproperations_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[operations]
			WHERE 
			[id] = @id
			";

		internal static string ctproperations_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[operations]
			(
			[externalid]
			,[name]
			,[shortname]
			)
			VALUES
			(
			@externalid
			,@name
			,@shortname
			)
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@name = [name]
			,@shortname = [shortname]
			FROM [dbo].[operations]
			WHERE 
			id = SCOPE_IDENTITY()
			";

		internal static string ctproperations_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[name]
			,[shortname]
			FROM [dbo].[operations]
			";

		internal static string ctproperations_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[operations]
			";

		internal static string ctproperations_SelectAllBySearchFields = @"
			
			-- selects all rows from the table according to search criteria
			SELECT 
			[id],
			[externalid],
			[name],
			[shortname]
			FROM [dbo].[operations]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([name] LIKE @name OR @name is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			";

		internal static string ctproperations_SelectAllBySearchFieldsCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table according to search criteria
			SELECT COUNT(*)
			FROM [dbo].[operations]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([name] LIKE @name OR @name is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			";

		internal static string ctproperations_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[operations]
			SET
			[externalid] = @externalid
			,[name] = @name
			,[shortname] = @shortname
			WHERE 
			[id] = @id
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@name = [name]
			,@shortname = [shortname]
			FROM [dbo].[operations]
			WHERE 
			[id] = @id
			";

	}
}
#endregion