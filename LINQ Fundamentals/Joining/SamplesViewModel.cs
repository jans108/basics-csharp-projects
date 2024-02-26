namespace LINQSamples
{
  public class SamplesViewModel : ViewModelBase
  {
    #region InnerJoinQuery
    /// <summary>
    /// Join a Sales Order collection with Products into anonymous class
    /// NOTE: This is an equijoin or an inner join
    /// </summary>
    public List<ProductOrder> InnerJoinQuery()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

      // Write Query Syntax Here
      list = (from p in products join s in sales on p.ProductID equals s.ProductID select new ProductOrder 
      {
          ProductID = p.ProductID,
          Name = p.Name,
          Color = p.Color,
          StandardCost = p.StandardCost,
          ListPrice = p.ListPrice,
          Size = p.Size,
          SalesOrderID = s.SalesOrderID,
          OrderQty = s.OrderQty,
          UnitPrice = s.UnitPrice,
          LineTotal = s.LineTotal
      }).OrderBy(p => p.Name).ToList();

      return list;
    }
    #endregion

    #region InnerJoinMethod
    /// <summary>
    /// Join a Sales Order collection with Products into anonymous class
    /// NOTE: This is an equijoin or an inner join
    /// </summary>
    public List<ProductOrder> InnerJoinMethod()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

      // Write Method Syntax Here
      list = products.Join(sales, p => p.ProductID, s => s.ProductID, (p, s) => new ProductOrder
      {
          ProductID = p.ProductID,
          Name = p.Name,
          Color = p.Color,
          StandardCost = p.StandardCost,
          ListPrice = p.ListPrice,
          Size = p.Size,
          SalesOrderID = s.SalesOrderID,
          OrderQty = s.OrderQty,
          UnitPrice = s.UnitPrice,
          LineTotal = s.LineTotal
      }).OrderBy(p =>p.Name).ToList();

      return list;
    }
    #endregion

    #region InnerJoinTwoFieldsQuery
    /// <summary>
    /// Join a Sales Order collection with Products collection using two fields
    /// </summary>
    public List<ProductOrder> InnerJoinTwoFieldsQuery()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

      // Write Query Syntax Here
      list = (from p in products join s in sales on
              new { p.ProductID, Qty = (short)6 }
              equals
              new { s.ProductID, Qty = s.OrderQty}
              select new ProductOrder
              {
                  ProductID= p.ProductID,
                  Name = p.Name,    
                  Color = p.Color,
                  StandardCost = p.StandardCost,
                  ListPrice = p.ListPrice,
                  Size = p.Size,
                  SalesOrderID = s.SalesOrderID,
                  OrderQty = s.OrderQty,
                  UnitPrice = s.UnitPrice,
                  LineTotal = s.LineTotal
              }).OrderBy(p => p.Name).ToList();

      return list;
    }
    #endregion

    #region InnerJoinTwoFieldsMethod
    /// <summary>
    /// Join a Sales Order collection with Products collection using two fields
    /// </summary>
    public List<ProductOrder> InnerJoinTwoFieldsMethod()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.Join(sales, p => new { p.ProductID, Qty = (short)6 },
                   s => new { s.ProductID, Qty = s.OrderQty },
                   (p, s) => new ProductOrder
                   {
                       ProductID = p.ProductID,
                       Name = p.Name,
                       Color = p.Color,
                       StandardCost = p.StandardCost,
                       ListPrice = p.ListPrice,
                       Size = p.Size,
                       SalesOrderID = s.SalesOrderID,
                       OrderQty = s.OrderQty,
                       UnitPrice = s.UnitPrice,
                       LineTotal = s.LineTotal
                   }).OrderBy(p => p.Name).ToList();

      return list;
    }
    #endregion

    #region JoinIntoQuery
    /// <summary>
    /// Use 'into' to create a new object with a Sales collection for each Product
    /// This is like a combination of an inner join and left outer join
    /// The 'into' keyword allows you to put the sales into a 'sales' variable 
    /// that can be used to retrieve all sales for a specific product
    /// </summary>
    public List<ProductSales> JoinIntoQuery()
    {
      List<ProductSales> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

      // Write Query Syntax Here
      list = (from p in products
              orderby p.ProductID
              join s in sales
              on p.ProductID equals s.ProductID
              into newSales
              select new ProductSales
              {
                  Product = p,
                  Sales = newSales.OrderBy(s => s.SalesOrderID).ToList()
              }).ToList();
            
      return list;
    }
    #endregion 

    #region JoinIntoMethod
    /// <summary>
    /// Use GroupJoin() to create a new object with a Sales collection for each Product
    /// This is like a combination of an inner join and left outer join
    /// The GroupJoin() method replaces the into keyword
    /// </summary>
    public List<ProductSales> JoinIntoMethod()
    {
      List<ProductSales> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.OrderBy(p => p.ProductID).GroupJoin(sales,
                  p => p.ProductID,
                  s => s.ProductID,
                  (p, newSales) => new ProductSales
                  {
                      Product = p,
                      Sales = newSales.OrderBy(s => s.SalesOrderID).ToList()
                  }).ToList();

      return list;
    }
    #endregion

    #region LeftOuterJoinQuery
    /// <summary>
    /// Perform a left join between Products and Sales using DefaultIfEmpty() and SelectMany()
    /// </summary>
    public List<ProductOrder> LeftOuterJoinQuery()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

      // Write Query Syntax Here
      list = (from p in products
              join s in sales
              on p.ProductID equals s.ProductID
              into newSales
              from s in newSales.DefaultIfEmpty()
              select new ProductOrder
              {
                  ProductID = p.ProductID,
                  Name = p.Name,
                  Color = p.Color,
                  StandardCost = p.StandardCost,
                  ListPrice = p.ListPrice,
                  Size = p.Size,
                  SalesOrderID = s?.SalesOrderID,
                  OrderQty = s?.OrderQty,
                  UnitPrice = s?.UnitPrice,
                  LineTotal = s?.LineTotal
              }).OrderBy(p => p.Name).ToList();

      return list;
    }
    #endregion

    #region LeftOuterJoinMethod
    /// <summary>
    /// Perform a left join between Products and Sales using DefaultIfEmpty() and SelectMany()
    /// </summary>
    public List<ProductOrder> LeftOuterJoinMethod()
    {
      List<ProductOrder> list = null;
      // Load all Product Data
      List<Product> products = ProductRepository.GetAll();
      // Load all Sales Order Data
      List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.SelectMany(p => sales.Where(s => s.ProductID == p.ProductID).DefaultIfEmpty(),
                (p, s) => new ProductOrder
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Color = p.Color,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    SalesOrderID = s?.SalesOrderID,
                    OrderQty = s?.OrderQty,
                    UnitPrice = s?.UnitPrice,
                    LineTotal = s?.LineTotal
                }).OrderBy(p => p.Name).ToList();

      return list;
    }
    #endregion
  }
}
