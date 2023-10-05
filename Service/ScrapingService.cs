using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebScraping.Entities;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace WebScraping.Controller
{
    public class ScrapingService
    {

        public void ScrapCvc()
        {

            //IWebDriver driver = new ChromeDriver();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito"); // Adiciona o argumento para abrir em modo incógnito

            IWebDriver driver = new ChromeDriver(options);


            // Navegar para a página da CVC
            driver.Navigate().GoToUrl("https://www.cvc.com.br");

            //driver.Manage().Window.Maximize();

            // Exemplo: Clicar em um link (Suponha que exista um link com o texto "Ofertas")
            IWebElement linkPassagens = driver.FindElement(By.XPath("//*[@id=\"menu-passagens\"]/span"));
            linkPassagens.Click();

            IWebElement origem = driver.FindElement(By.ClassName("cvc-core-577"));
            origem.Click();

            IWebElement origemNome = driver.FindElement(By.ClassName("input"));
            origemNome.SendKeys("Sao Paulo");

            Thread.Sleep(4000);

            IWebElement span = driver.FindElement(By.ClassName("bGGcZJZR7IsEsQjTbspD-html-close-button"));
            span.Click();

            Thread.Sleep(2000);

            IWebElement origem2 = driver.FindElement(By.ClassName("description"));
            origem2.Click();

            Thread.Sleep(2000);

            IWebElement aeroporto = driver.FindElement(By.XPath("//div[2]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[1]//div[3]"));
            aeroporto.Click();

            Thread.Sleep(2000);

            IWebElement destino = driver.FindElement(By.XPath("//div/div[2]/div[2]/div[2]/div/div[2]/div/div/div/div/div/div[3]"));
            destino.Click();

            IWebElement destinoNome = driver.FindElement(By.XPath("//div/div[2]/div[2]/div[2]/div/div[2]/div/div/div/div/div/div[3]/div/div/div/ul/li/div/input"));
            destinoNome.SendKeys("Rio de Janeiro");

            Thread.Sleep(2000);

            IWebElement aeroportoIda = driver.FindElement(By.XPath("//div/div[2]/div[2]/div[2]/div/div[2]/div/div/div/div/div/div[3]/div/div/div/ul/div"));
            aeroportoIda.Click();

            Thread.Sleep(2000);


            driver.Manage().Window.Maximize();


            /////////////////////

            Thread.Sleep(2000);

            // Encontrar o iframe pelo seu ID
            IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"DLiframe\"][2]"));


            Thread.Sleep(2000);
            // Mudar para o contexto do iframe
            driver.SwitchTo().Frame(iframe);

            Thread.Sleep(2000);
            // Encontrar e clicar no botão dentro do iframe
            IWebElement botao = driver.FindElement(By.XPath("//*[@id=\"DLapp\"]/div/div/div/div/div[2]/div[3]/div[2]"));
            botao.Click();

            Thread.Sleep(2000);
            // Voltar para o contexto principal da página
            driver.SwitchTo().DefaultContent();

            Thread.Sleep(2000);

            //////////////////////////////////////////


            IWebElement data = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/div/div/div/div[1]"));
            data.Click();

            Thread.Sleep(2000);
            IWebElement diaIda = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div/div[2]/div[2]/div/div[3]/div/table/tbody/tr[1]/td[4]"));
            diaIda.Click();
            Thread.Sleep(2000);
            IWebElement diavolta = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div/div[2]/div[2]/div/div[3]/div/table/tbody/tr[1]/td[7]"));
            diavolta.Click();

            IWebElement selecionar = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/div/div/div[2]/div/div[3]/div[2]/button"));
            selecionar.Click();

            IWebElement buscarVoos = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[2]/div[2]/div[2]/div/div[2]/div/div[2]/button"));
            buscarVoos.Click();

            Thread.Sleep(10000);
            var items = new List<Passagens>();

            //var elements = TypeElement.Xpath, "//*[@id=\"cards-list\"]")
            //    .element.FindElements(By.ClassName("cvc-core-8603"));

            //IWebElement elementoPai = driver.FindElement(By.XPath("//*[@id=\"cards-list\"]"));

            // IList<IWebElement> listaDeElementos = elementoPai.FindElements(By.XPath("//*[contains(text(), 'cvc-core')]")).ToList();

            try
            {
                var db = new Startup();
                for (int i = 2; i < 4; i++)
                {

                    string xpathCompanhia = $"//div[{i}]/div[2]/div[1]/div[1]/div/div[1]/div[1]/h6/span/span";
                    IWebElement companhia = driver.FindElement(By.XPath(xpathCompanhia));

                    string xpathPrecoTotal = $"//div[{i}]/div[2]/div[2]/div[1]/div[1]/div[2]/div/p/h5";
                    IWebElement precoTotal = driver.FindElement(By.XPath(xpathPrecoTotal));

                    string xpathTaxaDeEmbarque = $"//div[{i}]/div[2]/div[2]/div[1]/div[1]/div[2]/div/div/div[2]/span[2]";
                    IWebElement taxaDeEmbarque = driver.FindElement(By.XPath(xpathTaxaDeEmbarque));

                    string xpathTaxaDeServico = $"//div[{i}]/div[2]/div[2]/div[1]/div[1]/div[2]/div/div/div[3]/span[2]";
                    IWebElement taxaDeServico = driver.FindElement(By.XPath(xpathTaxaDeServico));

                    string xpathTempoDeVooIda = $"//div[{i}]/div[2]/div[1]/div[1]/div/div[2]/div[1]/div/span/span[1]";
                    IWebElement tempoDeVooIda = driver.FindElement(By.XPath(xpathTempoDeVooIda));

                    string xpathTempoDeVooVolta = $"//div[{i}]/div[2]/div[1]/div[2]/div/div[2]/div[1]/div/span/span[1]";
                    IWebElement tempoDeVooVolta = driver.FindElement(By.XPath(xpathTempoDeVooVolta));

                    string xpathDataIda = $"//div[{i}]/div[2]/div[1]/div[1]/div/div[1]/div[2]/p[1]";
                    IWebElement dataIda = driver.FindElement(By.XPath(xpathDataIda));

                    string xpathDataVolta = $"//div[{i}]/div[2]/div[1]/div[2]/div/div[1]/div[2]/p[1]";
                    IWebElement dataVolta = driver.FindElement(By.XPath(xpathDataVolta));


                    string textoCompanhia = companhia.Text;
                    string textoTaxaDeEmbarque = taxaDeEmbarque.Text;
                    string textoTaxaDeServico = taxaDeServico.Text;
                    string tempoTextoIda = tempoDeVooIda.Text;
                    string tempoTextoVolta = tempoDeVooVolta.Text;
                    string textoDataIda = dataIda.Text;
                    string textoDataVolta = dataVolta.Text;

                    string nomeCompanhia = textoCompanhia.Substring(1, textoCompanhia.Length - 2);
                    string valorTaxaEmbarque = ExtrairNumero(textoTaxaDeEmbarque);
                    string valorTaxaServico = ExtrairNumero(textoTaxaDeServico);
                    int totalMinutosIda = ExtrairTotalMinutos(tempoTextoIda);
                    int totalMinutosVolta = ExtrairTotalMinutos(tempoTextoVolta);
                    DateTime ida = ConverterTextoData(textoDataIda);
                    DateTime volta = ConverterTextoData(textoDataVolta);

                    var item = new Passagens();
                    
                    item.EMPRESA = "CVC";
                    item.COMPANHIA_DE_VOO = nomeCompanhia;
                    item.PRECO_TOTAL = precoTotal.Text;
                    item.TAXA_DE_EMBARQUE = valorTaxaEmbarque;
                    item.TAXA_DE_SERVICO = valorTaxaServico;
                    item.TEMPO_DE_VOO_IDA = totalMinutosIda;
                    item.TEMPO_DE_VOO_VOLTA = totalMinutosVolta;
                    item.DATA_HORA_DE_IDA = ida;
                    item.DATA_HORA_DE_VOLTA = volta;

                    //items.Add(item);

                    db.VOOS.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }



        public void ScrapDecolar()
        {

            //IWebDriver driver = new ChromeDriver();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito"); // Adiciona o argumento para abrir em modo incógnito

            IWebDriver driver = new ChromeDriver(options);


            // Navegar para a página da CVC
            driver.Navigate().GoToUrl("https://www.decolar.com/passagens-aereas/");

            IWebElement span = driver.FindElement(By.XPath("/html/body/nav/div[4]/div[2]/div[4]"));
            span.Click();


            IWebElement data = driver.FindElement(By.XPath("//div/div/div/div[3]/div[1]/div[1]/div[2]/div/div[1]/div/div/div"));
            data.Click();


            Thread.Sleep(1000);
            IWebElement diaIda = driver.FindElement(By.XPath("//div[1]/div[2]/div/div[2]/div[3]/div[1]"));//div[1]/div[2]/div/div[1]/div[3]/div[1]
            diaIda.Click();

            IWebElement diavolta = driver.FindElement(By.XPath("//div[1]/div[2]/div/div[1]/div[3]/div[4]"));//div[1]/div[2]/div/div[1]/div[3]/div[4]
            diavolta.Click();

            driver.Manage().Window.Maximize();


            IWebElement span2 = driver.FindElement(By.XPath("//*[@id=\"lgpd-banner\"]/div/div"));
            span2.Click();

            IWebElement aplicar = driver.FindElement(By.XPath("//div[1]/div[3]/div[1]/button"));
            aplicar.Click();

            IWebElement destino = driver.FindElement(By.XPath("//div/div/div/div[3]/div[1]/div[1]/div[1]/div/div[2]/div"));
            destino.Click();


            Thread.Sleep(2000);
            IWebElement destinoNome = driver.FindElement(By.XPath("//div/div/div/div[3]/div[1]/div[1]/div[1]/div/div[2]/div/div/input"));
            destinoNome.SendKeys("Rio de Janeiro");
            Thread.Sleep(2000);
            destinoNome.SendKeys(Keys.Enter);


            IWebElement buscarVoos = driver.FindElement(By.CssSelector(".sbox5-box-button-ovr--3LK5x.sbox5-3-btn")); //div/div/div/div[3]/div[4]/button
            buscarVoos.Click();


            Thread.Sleep(5000);
            IWebElement span3 = driver.FindElement(By.CssSelector(".ab-coupon-incentive--branch_true.btn-text")); //div/div/div/div[3]/div[4]/button
            span3.Click();

            Thread.Sleep(10000);
            var items = new List<Passagens>();

            string xpathCompanhia = $"//span[1]/div/span/cluster/div/div/div[1]/div/span/div/div/span[1]/route-choice/ul/li[1]/route/itinerary/div/div/div[1]/itinerary-element[2]/span/itinerary-element-airline/span/span/span/span/span[2]/span";
            IWebElement companhia = driver.FindElement(By.XPath(xpathCompanhia));

            string xpathPrecoTotal = $"//span[3]/div/span/cluster/div/div/div[2]/fare/span/span/fare-details-items/div/item-fare/p/span/flights-price/span/flights-price-element/span/span/em/span[2]";
            IWebElement precoTotal = driver.FindElement(By.XPath(xpathPrecoTotal));

            string xpathTaxaDeServico = $"//span[3]/div/span/cluster/div/div/div[2]/fare/span/span/fare-details-items/div/span/item-fare[2]/p/span/flights-price/span/flights-price-element/span/span/em";
            IWebElement taxaDeServico = driver.FindElement(By.XPath(xpathTaxaDeServico));

            string xpathTempoDeVooIda = $"//span[3]/div/span/cluster/div/div/div[1]/div/span/div/div/span[1]/route-choice/ul/li[1]/route/itinerary/div/div/div[3]/itinerary-element[2]/span/duration-item/span/span";
            IWebElement tempoDeVooIda = driver.FindElement(By.XPath(xpathTempoDeVooIda));

            string xpathTempoDeVooVolta = $"//span[3]/div/span/cluster/div/div/div[1]/div/span/div/div/span[2]/route-choice/ul/li/route/itinerary/div/div/div[3]/itinerary-element[2]/span/duration-item/span/span";
            IWebElement tempoDeVooVolta = driver.FindElement(By.XPath(xpathTempoDeVooVolta));

            string xpathDataIda = $"//span[3]/div/span/cluster/div/div/div[1]/div/span/div/div/span[1]/route-choice/div/span[1]/span[2]/route-info-item/span/span/span";
            IWebElement dataIda = driver.FindElement(By.XPath(xpathDataIda));

            string xpathDataVolta = $"//span[3]/div/span/cluster/div/div/div[1]/div/span/div/div/span[2]/route-choice/div/span[1]/span[2]/route-info-item/span/span/span";
            IWebElement dataVolta = driver.FindElement(By.XPath(xpathDataVolta));

            string textoTaxaDeServico = taxaDeServico.Text;
            string tempoTextoIda = tempoDeVooIda.Text;
            string tempoTextoVolta = tempoDeVooVolta.Text;
            string textoDataIda = dataIda.Text;
            string textoDataVolta = dataVolta.Text;

            string valorTaxa = ExtrairNumero(textoTaxaDeServico);
            int totalMinutosIda = ConverterTempoParaMinutos(tempoTextoIda);
            int totalMinutosVolta = ConverterTempoParaMinutos(tempoTextoVolta);
            DateTime ida = ConverterTextoParaData(textoDataIda);
            DateTime volta = ConverterTextoParaData(textoDataVolta);

            var item = new Passagens();

            item.EMPRESA = "Decolar";
            item.COMPANHIA_DE_VOO = companhia.Text;
            item.PRECO_TOTAL = precoTotal.Text;
            item.TAXA_DE_EMBARQUE = "";
            item.TAXA_DE_SERVICO = valorTaxa;
            item.TEMPO_DE_VOO_IDA = totalMinutosIda;
            item.TEMPO_DE_VOO_VOLTA = totalMinutosVolta;
            item.DATA_HORA_DE_IDA = ida;
            item.DATA_HORA_DE_VOLTA = volta;


            var db = new Startup();
            db.VOOS.Add(item);
            db.SaveChanges();
        }

        static int ExtrairTotalMinutos(string texto)
        {
            Match match = Regex.Match(texto, @"(\d+)h (\d+)min");

            if (match.Success)
            {
                int horas = int.Parse(match.Groups[1].Value);
                int minutos = int.Parse(match.Groups[2].Value);

                return horas * 60 + minutos;
            }
            else
            {
                throw new ArgumentException("Formato de texto inválido.");
            }
        }

        static string ExtrairNumero(string texto)
        {
            Match match = Regex.Match(texto, @"\d+");
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return null; // Ou outra ação em caso de não encontrar nenhum número.
            }
        }

        static int ConverterTempoParaMinutos(string tempo)
        {
            string[] partes = tempo.Split(' ');
            int horas = int.Parse(partes[0].Replace("h", ""));
            int minutos = int.Parse(partes[1].Replace("m", ""));

            return horas * 60 + minutos;
        }

        static DateTime ConverterTextoParaData(string textoData)
        {
            //CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");
            //string formato = "ddd. d MMM. yyyy";
            //DateTime data = DateTime.ParseExact(textoData, formato, cultura);
            //return data;

            string[] partes = textoData.Split(new char[] { ' ', '.', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            
            string nomeDoMes = partes[2];
            int mes = ConverterAbreviacaoParaNumero(nomeDoMes);


            int numeroDoDia = int.Parse(partes[1]);
            int ano = int.Parse(partes[3]);

            CultureInfo cultura = CultureInfo.CreateSpecificCulture("pt-BR");
            DateTime data = new DateTime(ano, mes, numeroDoDia);

            return data;
        }

        static DateTime ConverterTextoData(string textoData)
        {
            //CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");
            //string formato = "ddd. d MMM. yyyy";
            //DateTime data = DateTime.ParseExact(textoData, formato, cultura);
            //return data;

            string[] partes = textoData.Split(new char[] { ' ', '.', '\t' }, StringSplitOptions.RemoveEmptyEntries);


            string nomeDoMes = partes[3];
            int mes = ConverterAbreviacaoParaNumero(nomeDoMes);


            int numeroDoDia = int.Parse(partes[1]);
            int ano = DateTime.Now.Year;

            CultureInfo cultura = CultureInfo.CreateSpecificCulture("pt-BR");
            DateTime data = new DateTime(ano, mes, numeroDoDia);

            return data;
        }

        static int ConverterAbreviacaoParaNumero(string abreviacaoMes)
        {
            string[] nomesDosMeses = new string[]
            {
                "jan", "fev", "mar", "abr", "maio", "jun",
                "jul", "ago", "set", "out", "nov", "dez"
            };

            for (int i = 0; i < nomesDosMeses.Length; i++)
            {
                if (abreviacaoMes.Equals(nomesDosMeses[i], StringComparison.OrdinalIgnoreCase))
                {
                    return i + 1; // Adicionamos 1 porque os índices começam em 0, mas os meses em 1.
                }
            }

            throw new ArgumentException("Nome de mês inválido.");
        }

    }

}


