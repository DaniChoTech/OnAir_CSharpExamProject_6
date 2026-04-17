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

        public interface IGameUnit
        {
            // set은 왜 없어야하냐면, 익명 멤버변수를 만드는데
            // 이걸 인터페이스는 허용하지 않음 -> 인터페이스는 기능만 있어야해서
            string Name { get; }
            int Hp { get; }
            int Atk { get; }
        }

        public class GameUnitBase : IGameUnit
        {
            // 자식 클래스에서 쓸 수 있도록 protected set
            public string Name { get; protected set; }
            public int Hp { get; set; }
            public int Atk { get; set; }

            public void InitGameUnit(string name, int hp, int atk)
            {
                this.Name = name;
                this.Hp = hp;
                this.Atk = atk;
            }
        }

        public class PugPlayer : GameUnitBase
        {
            public void AttackMonster(Monster targetMonster)
            {
                targetMonster.Hp -= this.Atk;
                Console.WriteLine($"{this.Name}가 {this.Atk}만큼 공격해서" +
                    $" {targetMonster.Name}이 {targetMonster.Hp}만큼 남았다");
            }

            public bool IsRealDead()
            {
                bool isPlayerDead = (this.Hp <= 0);
                return isPlayerDead;
            }
        }

        public class Monster : GameUnitBase
        {
            public void AttackPlayer(PugPlayer targetPlayer)
            {
                targetPlayer.Hp -= this.Atk;
                Console.WriteLine($"{this.Name}가 {this.Atk}만큼 공격해서" +
                    $" {targetPlayer.Name}이 {targetPlayer.Hp}만큼 남았다");
            }
        }


        static void Main(string[] args)
        {
            // IGameUnit 인터페이스로도 보관 가능
            List<GameUnitBase> monsterInstanceList = new List<GameUnitBase>();


            Console.WriteLine("던전에 진입했다...두두둥 더 들어가시겠습니까? 안전은 보장할 수 없습니다 입장 : 1, 퇴장 : 2");
            string startKey = Console.ReadLine();

            if(startKey != "1") {
                Console.WriteLine("...퇴장을 선택했다.. 아무일도 일어나지 않았다...");
                Console.ReadLine();
                return;
            }

            PugPlayer player = new PugPlayer();
            player.InitGameUnit("퍼그용사", 100, 150);
            Console.WriteLine($"{player.Name}가 입장했다!");

            Monster mob103 = new Monster();
            mob103.InitGameUnit("슬라임", 300, 10);

            Monster mob777 = new Monster();
            mob777.InitGameUnit("유니콘", 1500, 10);

            Monster mob909 = new Monster();
            mob909.InitGameUnit("드래곤", 20, 10);

            // 생명체를 자료구조인 리스트에 보관
            monsterInstanceList.Add(mob103);
            monsterInstanceList.Add(mob777);
            monsterInstanceList.Add(mob909);

            // Foreach문에서 이름을 한개씩 출력
            foreach (var mobInstance in monsterInstanceList) { 
                Console.WriteLine($"{mobInstance.Name}");
            }

            while (_isGameOver == false) 
            {
                Console.WriteLine("...계단이 나왔다 더 들어갈 것인가! 내려간다 1, 퇴장한다 2");
                string repeatKey = Console.ReadLine();

                _isGameOver = player.IsRealDead();


                if (repeatKey == "1") {
                    player.AttackMonster(mob103);
                    mob103.AttackPlayer(player);
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
