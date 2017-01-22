using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    public class Algorithm
    {

        private Dictionary<TowerName, Stack<int>> towers;
        private List<Moove> mooves;


        public List<Moove> SolveHanoi(int n, TowerName from, TowerName to)
        {
            towers = new Dictionary<TowerName, Stack<int>>();
            towers[TowerName.A] = new Stack<int>();
            towers[TowerName.B] = new Stack<int>();
            towers[TowerName.C] = new Stack<int>();

            mooves = new List<Moove>();

            for(var i=n; i>0; i--)
            {
                towers[from].Push(i);
            }

            MooveHanoi(n, from, to);

            return mooves;
        }

        public void MooveHanoi(int count, TowerName from, TowerName to)
        {
            if (count == 1)
            {
                MooveOneDisk(from, to);
            }
            else
            {
                var aux = GetAuxWhen(from, to);

                MooveHanoi(count - 1, from, aux);
                MooveOneDisk(from, to);
                MooveHanoi(count - 1, aux, to);
            }
        }


        private static TowerName GetAuxWhen(TowerName from, TowerName to)
        {
            var all = Enum.GetValues(typeof(TowerName)).Cast<TowerName>();
            return all.First(a => a != from && a != to);
        }

        private void MooveOneDisk(TowerName from, TowerName to)
        {
            var diskId = towers[from].Pop();
            towers[to].Push(diskId);
            mooves.Add(new Moove(diskId, from, to));
        }

    }


    public class Moove
    {
        public Moove(int diskId, TowerName from, TowerName to)
        {
            DiskId = diskId;
            From = from;
            To = to;
        }

        public TowerName From { get; private set; }
        public int DiskId { get; private set; }
        public TowerName To { get; private set; }
    }

    public enum TowerName
    {
        A,
        B,
        C
    }
}