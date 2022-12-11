using System.Numerics;

public class Monkey
{
    public Func<BigInteger, BigInteger>? Operation {get; set;}
    public Func<BigInteger, int>? GetTarget { get; set;}
    public Queue<BigInteger> Items;
    public BigInteger Inspections {get; set;}

    public static Dictionary<int, Monkey> TestMonkeys = new () {
        {
            0,
            new Monkey{
                Operation = x => x * 19,
                GetTarget = x => x % 23 == 0 ? 2 : 3,
                Items = new Queue<BigInteger>(new BigInteger[] {79, 98})
            }
        },
        {
            1,
            new Monkey{
                Operation = x => x + 6,
                GetTarget = x => x % 19 == 0 ? 2 : 0,
                Items = new Queue<BigInteger>(new BigInteger[] {54, 65, 75, 74})
            }
        },
        {
            2,
            new Monkey{
                Operation = x => x * x,
                GetTarget = x => x % 13 == 0 ? 1 : 3,
                Items = new Queue<BigInteger>(new BigInteger[] {79, 60, 97})
            }
        },
        {
            3,
            new Monkey{
                Operation = x => x + 3,
                GetTarget = x => x % 17 == 0 ? 0 : 1,
                Items = new Queue<BigInteger>(new BigInteger[] {74})
            }
        },
    };

    public static Dictionary<int, Monkey> RealMonkeys = new () {
        {
            0,
            new Monkey{
                Operation = x => x * 3,
                GetTarget = x => x % 13 == 0 ? 1 : 5,
                Items = new Queue<BigInteger>(new BigInteger[] {53, 89, 62, 57, 74, 51, 83, 97})
            }
        },
        {
            1,
            new Monkey{
                Operation = x => x + 2,
                GetTarget = x => x % 19 == 0 ? 5 : 2,
                Items = new Queue<BigInteger>(new BigInteger[] {85, 94, 97, 92, 56})
            }
        },
        {
            2,
            new Monkey{
                Operation = x => x + 1,
                GetTarget = x => x % 11 == 0 ? 3 : 4,
                Items = new Queue<BigInteger>(new BigInteger[] {86, 82, 82})
            }
        },
        {
            3,
            new Monkey{
                Operation = x => x + 5,
                GetTarget = x => x % 17 == 0 ? 7 : 6,
                Items = new Queue<BigInteger>(new BigInteger[] {94, 68})
            }
        },
        {
            4,
            new Monkey{
                Operation = x => x + 4,
                GetTarget = x => x % 3 == 0 ? 3 : 6,
                Items = new Queue<BigInteger>(new BigInteger[] {83, 62, 74, 58, 96, 68, 85})
            }
        },
        {
            5,
            new Monkey{
                Operation = x => x + 8,
                GetTarget = x => x % 7 == 0 ? 2 : 4,
                Items = new Queue<BigInteger>(new BigInteger[] {50, 68, 95, 82})
            }
        },
        {
            6,
            new Monkey{
                Operation = x => x * 7,
                GetTarget = x => x % 5 == 0 ? 7 : 0,
                Items = new Queue<BigInteger>(new BigInteger[] {75})
            }
        },
        {
            7,
            new Monkey{
                Operation = x => x * x,
                GetTarget = x => x % 2 == 0 ? 0 : 1,
                Items = new Queue<BigInteger>(new BigInteger[] {92, 52, 85, 89, 68, 82})
            }
        },
    };
}