using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_DAL
{
    public class Produto
    {
        [Key]
        [Display(Name = "Id do Produto")]
        public int Id { get; set; }
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }
        [Display(Name = "Descriçao")]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }


        [Display(Name = "Linhas de Fatura")]
        // Um produto para várias linhas de fatura
        public virtual List<LinhaDeFatura> LinhasDeFatura { get; set; }
        

        //Chave estrangeira da classe Empregado
        [ForeignKey("Empregados")]
        [Display(Name = "Id Empregado")]
        public int IdEmpregado { get; set; }
        public virtual Empregado Empregado { get; set; }

    }

    public class Empregado
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome do Empregado")]
        public string NomeEmpregado { get; set; }
        [Display(Name = "Numero do Empregado")]
        public int NumeroEmpregado { get; set; }
        [Display(Name = "User do Empregado")]
        public string UserEmpregado { get; set; }

        public virtual List<Produto> Produtos { get; set; }
       
        public virtual List<Fatura> Faturas { get; set; }

    }



    public class Fatura
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Numero Fatura")]
        public int NumeroFatura { get; set; }
        public DateTime Data { get; set; }

        //Relaçao 1 para M 
        [Display(Name = "Linhas de Fatura")]
        public virtual List<LinhaDeFatura> LinhasDeFatura { get; set; }

        //Relaçao 1 para M
        [ForeignKey("Empregados")]
        public int IdEmpregado { get; set; }
        public virtual Empregado Empregados { get; set; }
    }

    public class LinhaDeFatura
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Quantidade")]
        public int QuantidadeLinha { get; set; }
        [Display(Name = "Preço")]
        public float PrecoLinha { get; set; }


        //Um Produto pode aparecer em muitas linhas - implementação de 1 Produto para N Linhas
        [ForeignKey("Produtos")]
        public int IdProduto { get; set; }
        public virtual Produto Produtos { get; set; }

        [ForeignKey("Faturas")]
        public int IdFaturas { get; set; }
        public virtual Fatura Faturas { get; set; }

    }
}
