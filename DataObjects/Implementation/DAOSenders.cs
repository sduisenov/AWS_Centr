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
	public partial class DAOSenders : DATACONN0_BaseData
	{
		#region member variables
		protected Int32? _id;
		protected Int64? _externalid;
		protected string _shortname;
		protected string _name;
		protected string _address;
		#endregion

		#region class methods
		public DAOSenders()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table senders based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSenders
		///</returns>
		///<parameters>
		///Int32? id
		///</parameters>
		public static DAOSenders SelectOne(Int32? id)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprsenders_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("senders");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)id?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSenders retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSenders();
					retObj._id					 = Convert.IsDBNull(dt.Rows[0]["id"]) ? (Int32?)null : (Int32?)dt.Rows[0]["id"];
					retObj._externalid					 = Convert.IsDBNull(dt.Rows[0]["externalid"]) ? (Int64?)null : (Int64?)dt.Rows[0]["externalid"];
					retObj._shortname					 = Convert.IsDBNull(dt.Rows[0]["shortname"]) ? null : (string)dt.Rows[0]["shortname"];
					retObj._name					 = Convert.IsDBNull(dt.Rows[0]["name"]) ? null : (string)dt.Rows[0]["name"];
					retObj._address					 = Convert.IsDBNull(dt.Rows[0]["address"]) ? null : (string)dt.Rows[0]["address"];
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
		///this method allows the object to delete itself from the table senders based on its primary key
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
			command.CommandText = InlineProcs.ctprsenders_DeleteOne;
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
		///This method saves a new object to the table senders
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
			command.CommandText = InlineProcs.ctprsenders_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _id));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_address?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;
				_address					 = Convert.IsDBNull(command.Parameters["@address"].Value) ? null : (string)command.Parameters["@address"].Value;

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
		///This method returns all data rows in the table senders
		///</Summary>
		///<returns>
		///IList-DAOSenders.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSenders> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprsenders_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("senders");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSenders> objList = new List<DAOSenders>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSenders retObj = new DAOSenders();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
						retObj._address					 = Convert.IsDBNull(row["address"]) ? null : (string)row["address"];
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
			command.CommandText = InlineProcs.ctprsenders_SelectAllCount;
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
		///IList-DAOSenders.
		///</returns>
		///<parameters>
		///DAOSenders daoSenders
		///</parameters>
		public static IList<DAOSenders> SelectAllBySearchFields(DAOSenders daoSenders)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprsenders_SelectAllBySearchFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("senders");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoSenders.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoSenders.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Address?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSenders> objList = new List<DAOSenders>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSenders retObj = new DAOSenders();
						retObj._id					 = Convert.IsDBNull(row["id"]) ? (Int32?)null : (Int32?)row["id"];
						retObj._externalid					 = Convert.IsDBNull(row["externalid"]) ? (Int64?)null : (Int64?)row["externalid"];
						retObj._shortname					 = Convert.IsDBNull(row["shortname"]) ? null : (string)row["shortname"];
						retObj._name					 = Convert.IsDBNull(row["name"]) ? null : (string)row["name"];
						retObj._address					 = Convert.IsDBNull(row["address"]) ? null : (string)row["address"];
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
		///DAOSenders daoSenders
		///</parameters>
		public static Int32 SelectAllBySearchFieldsCount(DAOSenders daoSenders)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprsenders_SelectAllBySearchFieldsCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)daoSenders.Id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)daoSenders.Externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 255, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)daoSenders.Address?? (object)DBNull.Value));

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
		///This method allows the object to update itself in the table senders based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprsenders_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@externalid", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_externalid?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@shortname", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_shortname?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_name?? (object)DBNull.Value));
				command.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar, 255, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_address?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@id"].Value;
				_externalid					 = Convert.IsDBNull(command.Parameters["@externalid"].Value) ? (Int64?)null : (Int64?)command.Parameters["@externalid"].Value;
				_shortname					 = Convert.IsDBNull(command.Parameters["@shortname"].Value) ? null : (string)command.Parameters["@shortname"].Value;
				_name					 = Convert.IsDBNull(command.Parameters["@name"].Value) ? null : (string)command.Parameters["@name"].Value;
				_address					 = Convert.IsDBNull(command.Parameters["@address"].Value) ? null : (string)command.Parameters["@address"].Value;

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

		public string Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
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
		internal static string ctprsenders_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[shortname]
			,[name]
			,[address]
			FROM [dbo].[senders]
			WHERE 
			[id] = @id
			";

		internal static string ctprsenders_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[senders]
			WHERE 
			[id] = @id
			";

		internal static string ctprsenders_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[senders]
			(
			[externalid]
			,[shortname]
			,[name]
			,[address]
			)
			VALUES
			(
			@externalid
			,@shortname
			,@name
			,@address
			)
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@shortname = [shortname]
			,@name = [name]
			,@address = [address]
			FROM [dbo].[senders]
			WHERE 
			id = SCOPE_IDENTITY()
			";

		internal static string ctprsenders_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[id]
			,[externalid]
			,[shortname]
			,[name]
			,[address]
			FROM [dbo].[senders]
			";

		internal static string ctprsenders_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[senders]
			";

		internal static string ctprsenders_SelectAllBySearchFields = @"
			
			-- selects all rows from the table according to search criteria
			SELECT 
			[id],
			[externalid],
			[shortname],
			[name],
			[address]
			FROM [dbo].[senders]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			AND ([name] LIKE @name OR @name is null)
			AND ([address] LIKE @address OR @address is null)
			";

		internal static string ctprsenders_SelectAllBySearchFieldsCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table according to search criteria
			SELECT COUNT(*)
			FROM [dbo].[senders]
			WHERE 
			([id] LIKE @id OR @id is null)
			AND ([externalid] LIKE @externalid OR @externalid is null)
			AND ([shortname] LIKE @shortname OR @shortname is null)
			AND ([name] LIKE @name OR @name is null)
			AND ([address] LIKE @address OR @address is null)
			";

		internal static string ctprsenders_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[senders]
			SET
			[externalid] = @externalid
			,[shortname] = @shortname
			,[name] = @name
			,[address] = @address
			WHERE 
			[id] = @id
			SELECT 
			@id = [id]
			,@externalid = [externalid]
			,@shortname = [shortname]
			,@name = [name]
			,@address = [address]
			FROM [dbo].[senders]
			WHERE 
			[id] = @id
			";

	}
}
#endregion
