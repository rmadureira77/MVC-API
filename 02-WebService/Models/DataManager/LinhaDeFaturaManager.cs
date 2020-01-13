using _01_DAL;
using _02_WebService.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_WebService.Models.DataManager
{
    public class LinhaDeFaturaManager : IDataRepositorio<LinhaDeFatura>
    {
        readonly DataContext _dataContext;

        public LinhaDeFaturaManager(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<LinhaDeFatura> GetAll()
        {
            return _dataContext.LinhasDeFatura.ToList();
        }

        public LinhaDeFatura Get(int id)
        {
            return _dataContext.LinhasDeFatura
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(LinhaDeFatura entity)
        {
            _dataContext.LinhasDeFatura.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(LinhaDeFatura linhadefatura, LinhaDeFatura entity)
        {
            linhadefatura.IdFaturas = linhadefatura.IdFaturas;
            linhadefatura.IdProduto = linhadefatura.IdProduto;
            linhadefatura.PrecoLinha = entity.PrecoLinha;
            linhadefatura.QuantidadeLinha = entity.QuantidadeLinha;            

            _dataContext.SaveChanges();
        }

        public void Delete(LinhaDeFatura linhadefatura)
        {
            _dataContext.LinhasDeFatura.Remove(linhadefatura);
            _dataContext.SaveChanges();
        }
    }

}
