using System;
using System.Collections.Generic;
using System.Text;
using VentasJHJ.Model.Data;
using VentasJHJ.Model.Domain;

namespace VentasJHJ.Model.Business
{
    public class CategoriaBusiness
    {
        CategoriaData categoriaData;
        String connectionString;

        public CategoriaBusiness(string connectionString)
        {
            this.connectionString = connectionString;
            this.categoriaData = new CategoriaData(connectionString);
        }

        public Categoria Insertar(Categoria categoria)
        {
            return categoriaData.Insertar(categoria);
        }
        public List<Categoria> GetAll()
        {
            return categoriaData.GetAll();
        }

    }


}
