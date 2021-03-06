/*************************************************************
** Class generated by CodeTrigger, Version 4.8.6.1
** This class was generated on 27.06.2018 13:13:08
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Collections.Generic;
using Awsd5.DataObjects;

namespace Awsd5.BusinessObjects
{
	///<Summary>
	///Class definition
	///This is the definition of the class BOProducttypes.
	///It maintains a collection of BOProducts objects.
	///</Summary>
	public partial class BOProducttypes : DATACONN0_BaseBusiness
	{
		#region member variables
		protected Int32? _id;
		protected string _name;
		protected Int64? _externalid;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOProducts> _boProductsCollection;
		/*********************************************/
		#endregion

		#region class methods
		///<Summary>
		///Constructor
		///This is the default constructor
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public BOProducttypes()
		{
		}

		///<Summary>
		///Constructor
		///Constructor using primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///Int32 id
		///</parameters>
		public BOProducttypes(Int32 id)
		{
			try
			{
				DAOProducttypes daoProducttypes = DAOProducttypes.SelectOne(id);
				_id = daoProducttypes.Id;
				_name = daoProducttypes.Name;
				_externalid = daoProducttypes.Externalid;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///Constructor
		///This constructor initializes the business object from its respective data object
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DAOProducttypes
		///</parameters>
		protected internal BOProducttypes(DAOProducttypes daoProducttypes)
		{
			try
			{
				_id = daoProducttypes.Id;
				_name = daoProducttypes.Name;
				_externalid = daoProducttypes.Externalid;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Producttypes record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOProducttypes daoProducttypes = new DAOProducttypes();
			RegisterDataObject(daoProducttypes);
			BeginTransaction("savenewBOProducttypes");
			try
			{
				daoProducttypes.Name = _name;
				daoProducttypes.Externalid = _externalid;
				daoProducttypes.Insert();
				CommitTransaction();
				
				_id = daoProducttypes.Id;
				_name = daoProducttypes.Name;
				_externalid = daoProducttypes.Externalid;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOProducttypes");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Producttypes record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOProducttypes
		///</parameters>
		public virtual void Update()
		{
			DAOProducttypes daoProducttypes = new DAOProducttypes();
			RegisterDataObject(daoProducttypes);
			BeginTransaction("updateBOProducttypes");
			try
			{
				daoProducttypes.Id = _id;
				daoProducttypes.Name = _name;
				daoProducttypes.Externalid = _externalid;
				daoProducttypes.Update();
				CommitTransaction();
				
				_id = daoProducttypes.Id;
				_name = daoProducttypes.Name;
				_externalid = daoProducttypes.Externalid;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOProducttypes");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Producttypes record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOProducttypes daoProducttypes = new DAOProducttypes();
			RegisterDataObject(daoProducttypes);
			BeginTransaction("deleteBOProducttypes");
			try
			{
				daoProducttypes.Id = _id;
				daoProducttypes.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOProducttypes");
				throw;
			}
		}
		
		///<Summary>
		///ProducttypesCollection
		///This method returns the collection of BOProducttypes objects
		///</Summary>
		///<returns>
		///List[BOProducttypes]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOProducttypes> ProducttypesCollection()
		{
			try
			{
				IList<BOProducttypes> boProducttypesCollection = new List<BOProducttypes>();
				IList<DAOProducttypes> daoProducttypesCollection = DAOProducttypes.SelectAll();
			
				foreach(DAOProducttypes daoProducttypes in daoProducttypesCollection)
					boProducttypesCollection.Add(new BOProducttypes(daoProducttypes));
			
				return boProducttypesCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ProducttypesCollectionCount
		///This method returns the collection count of BOProducttypes objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ProducttypesCollectionCount()
		{
			try
			{
				Int32 objCount = DAOProducttypes.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ProducttypesCollectionFromSearchFields
		///This method returns the collection of BOProducttypes objects, filtered by a search object
		///</Summary>
		///<returns>
		///List<BOProducttypes>
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOProducttypes> ProducttypesCollectionFromSearchFields(BOProducttypes boProducttypes)
		{
			try
			{
				IList<BOProducttypes> boProducttypesCollection = new List<BOProducttypes>();
				DAOProducttypes daoProducttypes = new DAOProducttypes();
				daoProducttypes.Id = boProducttypes.Id;
				daoProducttypes.Name = boProducttypes.Name;
				daoProducttypes.Externalid = boProducttypes.Externalid;
				IList<DAOProducttypes> daoProducttypesCollection = DAOProducttypes.SelectAllBySearchFields(daoProducttypes);
			
				foreach(DAOProducttypes resdaoProducttypes in daoProducttypesCollection)
					boProducttypesCollection.Add(new BOProducttypes(resdaoProducttypes));
			
				return boProducttypesCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ProducttypesCollectionFromSearchFieldsCount
		///This method returns the collection count of BOProducttypes objects, filtered by a search object
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ProducttypesCollectionFromSearchFieldsCount(BOProducttypes boProducttypes)
		{
			try
			{
				DAOProducttypes daoProducttypes = new DAOProducttypes();
				daoProducttypes.Id = boProducttypes.Id;
				daoProducttypes.Name = boProducttypes.Name;
				daoProducttypes.Externalid = boProducttypes.Externalid;
				Int32 objCount = DAOProducttypes.SelectAllBySearchFieldsCount(daoProducttypes);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ProductsCollection
		///This method returns its collection of BOProducts objects
		///</Summary>
		///<returns>
		///IList[BOProducts]
		///</returns>
		///<parameters>
		///BOProducttypes
		///</parameters>
		public virtual IList<BOProducts> ProductsCollection()
		{
			try
			{
				if(_boProductsCollection == null)
					LoadProductsCollection();
				
				return _boProductsCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadProductsCollection
		///This method loads the internal collection of BOProducts objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadProductsCollection()
		{
			try
			{
				_boProductsCollection = new List<BOProducts>();
				IList<DAOProducts> daoProductsCollection = DAOProducts.SelectAllByProducttypeid(_id.Value);
				
				foreach(DAOProducts daoProducts in daoProductsCollection)
					_boProductsCollection.Add(new BOProducts(daoProducts));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddProducts
		///This method persists a BOProducts object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOProducts
		///</parameters>
		public virtual void AddProducts(BOProducts boProducts)
		{
			DAOProducts daoProducts = new DAOProducts();
			RegisterDataObject(daoProducts);
			BeginTransaction("addProducts");
			try
			{
				daoProducts.Id = boProducts.Id;
				daoProducts.Name = boProducts.Name;
				daoProducts.Shortname = boProducts.Shortname;
				daoProducts.Externalid = boProducts.Externalid;
				daoProducts.Producttypeid = _id.Value;
				daoProducts.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boProducts = new BOProducts(daoProducts);
				if(_boProductsCollection != null)
					_boProductsCollection.Add(boProducts);
			}
			catch
			{
				RollbackTransaction("addProducts");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllProducts
		///This method deletes all BOProducts objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllProducts()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllProducts");
			try
			{
				DAOProducts.DeleteAllByProducttypeid(ConnectionProvider, _id.Value);
				CommitTransaction();
				if(_boProductsCollection != null)
				{
					_boProductsCollection.Clear();
					_boProductsCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllProducts");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? Id
		{
			get
			{
				 return _id;
			}
			set
			{
				_id = value;
				_isDirty = true;
			}
		}
		
		public virtual string Name
		{
			get
			{
				 return _name;
			}
			set
			{
				_name = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? Externalid
		{
			get
			{
				 return _externalid;
			}
			set
			{
				_externalid = value;
				_isDirty = true;
			}
		}
		
		public virtual object Repository
		{
			get {	return null;	}
			set	{	}
		}
		
		public virtual bool IsDirty
		{
			get
			{
				 return _isDirty;
			}
			set
			{
				_isDirty = value;
			}
		}
		#endregion
	}
}
