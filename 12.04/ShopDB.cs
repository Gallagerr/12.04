using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace _12._04
{
  public class ShopDB
  {
    public static void Creation()
    {
      DataSet ShopDB = new DataSet("ShopDB");
      DataTable Orders = new DataTable("Orders");
      DataTable Customers = new DataTable("Customers");
      DataTable Employees = new DataTable("Employees");
      DataTable OrderDetails = new DataTable("OrderDetails");
      DataTable Products = new DataTable("Products");

      InitOrder(ref Orders);
      InitCustomers(ref Customers);
      InitEmployees(ref Employees);
      InitOrderDetails(ref OrderDetails);
      InitProducts(ref Products);

      ForeignKeyConstraint FK_Order_OrderDetails = new ForeignKeyConstraint(OrderDetails.Columns["Id"], Orders.Columns["OrderDetailsId"]);
      ForeignKeyConstraint FK_OrderDetails_Product = new ForeignKeyConstraint(Products.Columns["Id"], OrderDetails.Columns["ProductId"]);
      ForeignKeyConstraint FK_OrderDetails_Customers = new ForeignKeyConstraint(Customers.Columns["Id"], OrderDetails.Columns["CustomersId"]);
      ForeignKeyConstraint FK_OrderDetails_Employees = new ForeignKeyConstraint(Employees.Columns["Id"], OrderDetails.Columns["EmployeesId"]);

      ShopDB.Tables.AddRange
      (
          new DataTable[]
          {
                    Orders, Customers, Employees, OrderDetails, Products
          }
      );
    }

    public static void InitOrder(ref DataTable orders)
    {
      DataColumn id = new DataColumn("Id", typeof(int));
      id.Caption = "Id";
      id.AllowDBNull = false;
      id.Unique = true;
      id.ReadOnly = true;
      id.AutoIncrement = true;
      id.AutoIncrementSeed = 1;
      id.AutoIncrementStep = 1;

      DataColumn orderDetailsId = new DataColumn("OrderDetailsId", typeof(int))
      {
        Caption = "DetailsId",
        AllowDBNull = false,
      };

      orders.Columns.AddRange
      (
          new DataColumn[]
          {
                    id, orderDetailsId
          }
      );

      orders.PrimaryKey = new DataColumn[] { orders.Columns[0] };
    }

    public static void InitCustomers(ref DataTable customers)
    {
      DataColumn id = new DataColumn("Id", typeof(int));
      id.Caption = "Id";
      id.AllowDBNull = false;
      id.Unique = true;
      id.ReadOnly = true;
      id.AutoIncrement = true;
      id.AutoIncrementSeed = 1;
      id.AutoIncrementStep = 1;

      DataColumn name = new DataColumn("Name", typeof(string));
      name.Caption = "Name";
      name.AllowDBNull = false;
      name.MaxLength = 20;

      DataColumn surname = new DataColumn("LastName", typeof(string));
      surname.Caption = "LastName";
      surname.AllowDBNull = false;
      surname.MaxLength = 20;

      customers.Columns.AddRange
      (
          new DataColumn[]
          {
                    id, name, surname
          }
      );
      customers.PrimaryKey = new DataColumn[] { customers.Columns[0] };

    }

    public static void InitEmployees(ref DataTable employees)
    {
      DataColumn id = new DataColumn("Id", typeof(int));
      id.Caption = "Id";
      id.AllowDBNull = false;
      id.Unique = true;
      id.ReadOnly = true;
      id.AutoIncrement = true;
      id.AutoIncrementSeed = 1;
      id.AutoIncrementStep = 1;

      DataColumn name = new DataColumn("Name", typeof(string));
      name.Caption = "Name";
      name.AllowDBNull = false;
      name.MaxLength = 20;

      DataColumn surname = new DataColumn("LastName", typeof(string));
      surname.Caption = "LastName";
      surname.AllowDBNull = false;
      surname.MaxLength = 20;

      employees.Columns.AddRange
      (
          new DataColumn[]
          {
                    id, name, surname
          }
      );

      employees.PrimaryKey = new DataColumn[] { employees.Columns[0] };

    }

    public static void InitOrderDetails(ref DataTable orderDetails)
    {
      DataColumn id = new DataColumn("Id", typeof(int));
      id.Caption = "Id";
      id.AllowDBNull = false;
      id.Unique = true;
      id.ReadOnly = true;
      id.AutoIncrement = true;
      id.AutoIncrementSeed = 1;
      id.AutoIncrementStep = 1;

      DataColumn price = new DataColumn("Price", typeof(double))
      {
        Caption = "Prise for one",
        AllowDBNull = false
      };

      DataColumn orderDate = new DataColumn("OrderDate", typeof(DateTime))
      {
        Caption = "Date",
        AllowDBNull = false
      };

      DataColumn productId = new DataColumn("ProductId", typeof(int))
      {
        Caption = "ProductId",
        AllowDBNull = false,
      };

      DataColumn customersId = new DataColumn("CustomersId", typeof(int))
      {
        Caption = "CustomersId",
        AllowDBNull = false,
      };

      DataColumn employeesId = new DataColumn("EmployeesId", typeof(int))
      {
        Caption = "EmployeesId",
        AllowDBNull = false,
      };

      orderDetails.Columns.AddRange
     (
         new DataColumn[]
         {
                    id, price, orderDate,productId, customersId, employeesId
         }
     );
      orderDetails.PrimaryKey = new DataColumn[] { orderDetails.Columns[0] };
    }
    public static void InitProducts(ref DataTable products)
    {
      DataColumn id = new DataColumn("Id", typeof(int));
      id.Caption = "Id";
      id.AllowDBNull = false;
      id.Unique = true;
      id.ReadOnly = true;
      id.AutoIncrement = true;
      id.AutoIncrementSeed = 1;
      id.AutoIncrementStep = 1;

      DataColumn productName = new DataColumn("ProductName", typeof(string));
      productName.Caption = "ProductName";
      productName.AllowDBNull = false;
      productName.MaxLength = 30;

      products.Columns.AddRange
      (
          new DataColumn[]
          {
                    id, productName
          }
      );
      products.PrimaryKey = new DataColumn[] { products.Columns[0] };
    }
  }
}