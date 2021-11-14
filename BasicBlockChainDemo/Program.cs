using Newtonsoft.Json;
using System;

namespace BasicBlockChainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain phillyCoin = new Blockchain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Rubel,receiver:Samad,amount:10}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Samad,receiver:Rubel,amount:5}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Samad,receiver:Rubel,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));

            //Tampering One Node ItReturn Invalid
            Console.WriteLine($"Update amount to 1000");
            phillyCoin.Chain[1].Data = "{sender:Rubel,receiver:Samad,amount:1000}";

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            //But Tampering All Node it Return Valid. But Tampering All Node Impossible
            phillyCoin.Chain[1].Hash = phillyCoin.Chain[1].CalculateHash();
            Console.WriteLine($"Update the entire chain");
            phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            Console.ReadKey();
        }
    }
}
