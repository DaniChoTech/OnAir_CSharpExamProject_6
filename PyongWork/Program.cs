using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyongWork
{
    internal class Program
    {
        static bool _isGameOver = false;

        public class PugPlayer
        {
            public string Name { get; private set; }
            public int Hp { get; private set; }

            public void InitPugPlayer(string name, int hp)
            {
                this.Name = name;
                this.Hp = hp;
            }

            public void AttackMonster()
            {
            }
        }


        public class Monster
        {
            public string Name { get; private set; }
            public int Hp { get; private set; }

            public void InitMonster(string name, int hp)
            {
                this.Name = name;
                this.Hp = hp;
            }

            public void AttackPlayer()
            {
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("던전에 진입했다...두두둥 더 들어가시겠습니까? 안전은 보장할 수 없습니다 입장 : 1, 퇴장 : 2");
            string startKey = Console.ReadLine();

            if(startKey != "1") {
                Console.WriteLine("...퇴장을 선택했다.. 아무일도 일어나지 않았다...");
                Console.ReadLine();
                return;
            }

            PugPlayer player = new PugPlayer();
            player.InitPugPlayer("퍼그용사", 100);
            Console.WriteLine($"{player.Name}가 입장했다!");

            Monster mob103 = new Monster();
            mob103.InitMonster("슬라임", 300);



            while (_isGameOver == false) 
            {
                Console.WriteLine("...계단이 나왔다 더 들어갈 것인가! 내려간다 1, 퇴장한다 2");
                string repeatKey = Console.ReadLine();


                if (repeatKey == "1") {

                } 
                else if (repeatKey == "2") { 
                    
                
                } 
                else
                {
                    Console.WriteLine("잘못된 입력입니다..");
                }
            }

        }
    }
}
