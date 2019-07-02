using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Test.Data
{
    [TestClass]
    public class UnitTest1 {
        String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //[TestMethod]
        //public void TestInsertClient()
        //{
        //  Cliente cliente = new Cliente();
        //cliente.IdCliente = 100;
        // cliente.NombreCliente = "Juan";
        //cliente.ApellidosCliente = "Araya Martinez";
        //cliente.CedulaCliente = "3525884754";
        //cliente.DireccionCliente = "Agua Caliente Cartago";
        //cliente.EmailCliente = "juanaraya15@gmail.com";
        //cliente.PasswordCliente = "user";
        //cliente.TelefonoCliente = "65465465";
        //String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //ClienteData clienteData = new ClienteData(connectionString);
        //clienteData.Insertar(cliente);
        //}

        //[TestMethod]
        //public void TestDeleteClient()
        //{

        //    String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //    ClienteData clienteData = new ClienteData(connectionString);
        //        clienteData.Eliminar(11);
        //}

        //[TestMethod]
        //public void TestFindAllClient()
        //{

        //    String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //    ClienteData clienteData = new ClienteData(connectionString);

        //    List<Cliente> clientes = new List<Cliente>();
        //    clientes= clienteData.GetAll();
        //    foreach (Cliente item in clientes)
        //    {
        //        System.Console.WriteLine(item.NombreCliente);
        //    }

        //}

        //[TestMethod]
        //public void TestUpdateClient()
        //{

        //    String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //    ClienteData clienteData = new ClienteData(connectionString);
        //    Cliente cliente = new Cliente();
        //    cliente.IdCliente = 10;
        //    cliente.NombreCliente = "Juan";
        //    cliente.ApellidosCliente = "Araya Martinez";
        //    cliente.CedulaCliente = "3525884754";
        //    cliente.DireccionCliente = "Agua Caliente Cartago";
        //    cliente.EmailCliente = "juanaraya15@gmail.com";
        //    cliente.PasswordCliente = "user";
        //    cliente.TelefonoCliente = "65465465";
        //    clienteData.Editar(cliente);



        //}


        //[TestMethod]
        //public void TestInsertProduct()
        //{

        //    Categoria categoria = new Categoria();
        //    categoria.IdCategoria = 2;
        //    categoria.NombreCategoria = "Jardineria";
        //    Producto producto = new Producto();
        //    producto.NombreProducto = "manguera";
        //    producto.Descripcion = "15 metros";
        //    producto.CantidadEnStock = 10;
        //    producto.Precio = 7000;
        //    producto.Categoria = categoria;
        //    String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //    ProductoData productoData = new ProductoData(connectionString);
        //    productoData.Insertar(producto);
        //}

        //      [TestMethod]
        //      public void TestInsertCategoria()
        //       {
        //
        //         Categoria categoria = new Categoria();
        //          categoria.NombreCategoria = "Infantil";
        //          String connectionString = "Data Source=163.178.173.148;Initial Catalog=IF4101_I2019_B67781_B66774_B60512; User ID=estudiantesrp;Password=estudiantesrp";
        //          CategoriaData categoriaData = new CategoriaData(connectionString);
        //          categoriaData.Insertar(categoria);
        //      }

        //[TestMethod]
        //      public void TestGetAllProductos()
        //      {

        //    List<Producto> productos = new List<Producto>();
        //    ProductoData pd = new ProductoData(connectionString);
        //    productos = pd.GetByName("manguera");



        //      }

        //[TestMethod]
        //public void TestCrearOrden()
        //{
        //    Cliente cliente = new Cliente();
        //    cliente.IdCliente = 10;
        //    OrdenData ordenData = new OrdenData(connectionString);
        //    PosOrden orden = new PosOrden();
        //    orden.Cliente = cliente;
        //    ProductoPosOrden detalleOrden = new ProductoPosOrden();
        //    detalleOrden.Impuesto = 13;
        //    orden.DetalleOrden = detalleOrden;
        //    ordenData.Insertar(orden);



        //}

        [TestMethod]
        public void TestProductoInsert()
        {
            Producto producto = new Producto();
            producto.IdProducto = 4;
            List<Producto> productos = new List<Producto>();
            productos.Add(producto);
            ProductoCliente productoCliente = new ProductoCliente();
            OrdenData ordenData = new OrdenData(connectionString);
            productoCliente.Impuesto = 13;
            productoCliente.PrecioSubtotal = 3000;
            productoCliente.Cantidad = 1;
            productoCliente.PrecioUnitario = 2500;
            productoCliente.Descuento = 0;
            Cliente cliente = new Cliente();
            cliente.IdCliente = 10;
            productoCliente.Cliente = cliente;
            productoCliente.Productos = productos;
            ordenData.InsertarProductoCliente(productoCliente);




        }
    }
}
