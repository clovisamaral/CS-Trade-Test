using Application.Domain.Entities;
using Application.Services;
using Application.Services.Interfaces;
using System.Data;
using System.Globalization;

ITradeService service = new TradeService();
List<Trade> listTrade = new List<Trade>();

string referenceDate="";
int countReg = 0;

DateTime date;

if (ReadFileBase().Count() > 0)
{
    referenceDate = ReadFileBase()[0].ToString();
    countReg = int.Parse(ReadFileBase()[1].ToString());

    PrintOutPut(ListTrades(), DateTime.Parse(referenceDate));
}

List<Trade> ListTrades()
{
    if (ReadFileBase().Count()-2 == countReg)
    {
        for (int i = 2; i < ReadFileBase().Count(); i++)
        {
            var recordsLine = ReadFileBase()[i].Split(null);

            Trade trade = new Trade();

            if (recordsLine != null)
            {
                if (!string.IsNullOrEmpty(recordsLine[0].ToString()))
                {
                    var isDouble = double.TryParse(recordsLine[0].ToString(), out double value);
                    if (isDouble)
                    {
                        trade.Value = double.Parse(recordsLine[0].ToString());
                    }
                }

                if (!string.IsNullOrEmpty(recordsLine[1].ToString()))
                {
                    trade.ClientSector = recordsLine[1].ToString().ToUpper();
                }

                if (!string.IsNullOrEmpty(recordsLine[2].ToString()))
                {
                    var isDate = DateTime.TryParseExact(recordsLine[2].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out date);
                    if (isDate)
                    {
                        trade.NextPaymentDate = date;
                    }
                }

                listTrade.Add(trade);
            }
        }
    }

    return listTrade;
}

void PrintOutPut(List<Trade> trades, DateTime referenceDate)
{
    Console.WriteLine("************OUTPUT************");
    Console.WriteLine("");
    foreach (var item in trades)
    {
        var risk = service.GetCategory(item,referenceDate).ToString().ToUpper();
        Console.WriteLine(risk);
    }
    Console.ReadKey();
}

string[] ReadFileBase()
{
    DataTable table = new DataTable();

    var directory = System.Environment.CurrentDirectory;
    var filename = "FileBase.txt";

    var file = System.IO.Path.Combine(directory, filename);

    var lines = File.ReadAllLines(file);

    return lines;
}
