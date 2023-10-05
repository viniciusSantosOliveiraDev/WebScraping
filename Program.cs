
using WebScraping.Controller;
using WebScraping.Entities;

namespace WebScraping
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ScrapingService scrapingService = new ScrapingService(); // Criando uma instância da classe
            scrapingService.ScrapCvc();
            scrapingService.ScrapDecolar();

            var db = new Startup();
            var passagem = db.ConsultarMelhorPassagem();

            foreach (var produto in passagem)
            {
                Console.WriteLine($"EMPRESA: {produto.EMPRESA}, Companhia: {produto.COMPANHIA_DE_VOO}, PrecoTotal: {produto.PRECO_TOTAL}");
            }

        }

        
    }
}