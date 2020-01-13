using _01_DAL;
using _02_WebService.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_WebService.Models.DataManager
{
    public class ProdutoManager : IDataRepositorio<Produto>
    {
        readonly DataContext _dataContext;

        public ProdutoManager(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _dataContext.Produtos.ToList();
        }

        public Produto Get(int id)
        {
            return _dataContext.Produtos
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Produto entity)
        {
            _dataContext.Produtos.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Produto produto, Produto entity)
        {
            produto.NomeProduto = entity.NomeProduto;
            produto.Descricao = entity.Descricao;
            produto.Preco = entity.Preco;
            produto.Quantidade = entity.Quantidade;
            produto.IdEmpregado = entity.IdEmpregado;
                             
            _dataContext.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            _dataContext.Produtos.Remove(produto);
            _dataContext.SaveChanges();
        }
    }

}
